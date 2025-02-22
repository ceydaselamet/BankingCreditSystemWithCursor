using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using BankingCreditSystem.Application.Features.LoanApplications.Rules;
using BankingCreditSystem.Application.Services.Repositories;
using BankingCreditSystem.Domain.Entities;

namespace BankingCreditSystem.Application.Features.LoanApplications.Commands.Create
{
    public class CreateLoanApplicationCommand : IRequest<CreateLoanApplicationResponse>
    {
        public CreateLoanApplicationRequest Request { get; set; } = default!;

        public class CreateLoanApplicationCommandHandler : IRequestHandler<CreateLoanApplicationCommand, CreateLoanApplicationResponse>
        {
            private readonly ILoanApplicationRepository _loanApplicationRepository;
            private readonly ILoanTypeRepository _loanTypeRepository;
            private readonly IMapper _mapper;
            private readonly LoanApplicationBusinessRules _businessRules;

            public CreateLoanApplicationCommandHandler(
                ILoanApplicationRepository loanApplicationRepository,
                ILoanTypeRepository loanTypeRepository,
                IMapper mapper,
                LoanApplicationBusinessRules businessRules)
            {
                _loanApplicationRepository = loanApplicationRepository;
                _loanTypeRepository = loanTypeRepository;
                _mapper = mapper;
                _businessRules = businessRules;
            }

            public async Task<CreateLoanApplicationResponse> Handle(CreateLoanApplicationCommand request, CancellationToken cancellationToken)
            {
                await _businessRules.LoanTypeShouldExist(request.Request.LoanTypeId);
                await _businessRules.CheckLoanAmountLimits(request.Request.LoanTypeId, request.Request.RequestedAmount);
                await _businessRules.CheckLoanTermLimits(request.Request.LoanTypeId, request.Request.RequestedTerm);

                var loanType = await _loanTypeRepository.GetAsync(request.Request.LoanTypeId);
                
                var loanApplication = new LoanApplication
                {
                    CustomerId = request.Request.CustomerId,
                    LoanTypeId = request.Request.LoanTypeId,
                    RequestedAmount = request.Request.RequestedAmount,
                    RequestedTerm = request.Request.RequestedTerm,
                    InterestRate = loanType!.BaseInterestRate,
                    MonthlyPayment = CalculateMonthlyPayment(request.Request.RequestedAmount, loanType.BaseInterestRate, request.Request.RequestedTerm),
                    TotalPayment = CalculateTotalPayment(request.Request.RequestedAmount, loanType.BaseInterestRate, request.Request.RequestedTerm),
                    Status = LoanApplicationStatus.Pending
                };

                await _loanApplicationRepository.AddAsync(loanApplication);
                return _mapper.Map<CreateLoanApplicationResponse>(loanApplication);
            }

            private decimal CalculateMonthlyPayment(decimal principal, decimal annualInterestRate, int termInMonths)
            {
                decimal monthlyInterestRate = annualInterestRate / 12 / 100;
                decimal monthlyPayment = principal * monthlyInterestRate * 
                    (decimal)Math.Pow(1 + (double)monthlyInterestRate, termInMonths) / 
                    ((decimal)Math.Pow(1 + (double)monthlyInterestRate, termInMonths) - 1);
                
                return Math.Round(monthlyPayment, 2);
            }

            private decimal CalculateTotalPayment(decimal principal, decimal annualInterestRate, int termInMonths)
            {
                decimal monthlyPayment = CalculateMonthlyPayment(principal, annualInterestRate, termInMonths);
                return Math.Round(monthlyPayment * termInMonths, 2);
            }
        }
    }
} 