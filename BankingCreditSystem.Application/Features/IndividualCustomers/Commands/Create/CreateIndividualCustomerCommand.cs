using AutoMapper;
using BankingCreditSystem.Application.Features.IndividualCustomers.Rules;
using BankingCreditSystem.Application.Features.IndividualCustomers.Dtos;
using BankingCreditSystem.Application.Services.Repositories;
using BankingCreditSystem.Domain.Entities;
using MediatR;
using BankingCreditSystem.Application.Features.IndividualCustomers.Dtos.Responses;
using BankingCreditSystem.Application.Features.IndividualCustomers.Dtos.Requests;

namespace BankingCreditSystem.Application.Features.IndividualCustomers.Commands.Create;

public class CreateIndividualCustomerCommand : IRequest<CreateIndividualCustomerResponse>
{
    public CreateIndividualCustomerRequest Request { get; set; } = default!;

    public class CreateIndividualCustomerCommandHandler : IRequestHandler<CreateIndividualCustomerCommand, CreateIndividualCustomerResponse>
    {
        private readonly IIndividualCustomerRepository _individualCustomerRepository;
        private readonly IMapper _mapper;
        private readonly IndividualCustomerBusinessRules _businessRules;

        public CreateIndividualCustomerCommandHandler(
            IIndividualCustomerRepository individualCustomerRepository,
            IMapper mapper,
            IndividualCustomerBusinessRules businessRules)
        {
            _individualCustomerRepository = individualCustomerRepository;
            _mapper = mapper;
            _businessRules = businessRules;
        }

        public async Task<CreateIndividualCustomerResponse> Handle(CreateIndividualCustomerCommand request, CancellationToken cancellationToken)
        {
            await _businessRules.NationalIdCannotBeDuplicated(request.Request.NationalId);

            var individualCustomer = _mapper.Map<IndividualCustomer>(request.Request);
            await _individualCustomerRepository.AddAsync(individualCustomer, cancellationToken);

            return _mapper.Map<CreateIndividualCustomerResponse>(individualCustomer);
        }
    }
} 