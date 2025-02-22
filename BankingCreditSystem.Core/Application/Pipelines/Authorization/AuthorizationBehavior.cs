using BankingCreditSystem.Core.CrossCuttingConcerns.Exceptions.Types;
using BankingCreditSystem.Core.Security.Extensions;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace BankingCreditSystem.Core.Application.Pipelines.Authorization;

public class AuthorizationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>, ISecuredRequest
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AuthorizationBehavior(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var userRoles = _httpContextAccessor.HttpContext?.User.ClaimRoles();

        if (userRoles == null) throw new AuthorizationException("Claims not found.");

        bool isNotMatchedARoleClaimWithRequestRoles = 
            request.Roles.Any() && !request.Roles.Any(role => userRoles.Contains(role));
            
        if (isNotMatchedARoleClaimWithRequestRoles) 
            throw new AuthorizationException("You are not authorized.");

        TResponse response = await next();
        return response;
    }
} 