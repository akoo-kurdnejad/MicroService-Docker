﻿using MediatR;
using Microsoft.Extensions.Logging;

namespace Ordering.ApplicationService.Infrastructure.MediatR.PipelineBehavior
{
    public class UnHandledExeptionBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly ILogger<TRequest> _logger;
        public UnHandledExeptionBehavior(ILogger<TRequest> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            try
            {
                return await next();
            }
            catch (Exception ex)
            {
                var requestName = typeof(TRequest).Name;
                _logger.LogError(ex, $"Application request :Unhandled Exeption for request {requestName}, {request} ");
                throw;
            }
        }
    }
}
