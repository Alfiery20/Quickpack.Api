﻿using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using Quickpack.Application.Common.Interface;

namespace Quickpack.Application.Common.Behaviours
{
    public class RequestLogger<TRequest> : IRequestPreProcessor<TRequest>
    {
        private readonly ILogger _logger;
        private readonly ICurrentUser _currentUser;

        public RequestLogger(ILogger<TRequest> logger, ICurrentUser currentUser)
        {
            _logger = logger;
            _currentUser = currentUser;
        }

        public Task Process(TRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Procesando request {0} de {1}", typeof(TRequest).Name, _currentUser.Id);

            return Task.CompletedTask;
        }
    }
}
