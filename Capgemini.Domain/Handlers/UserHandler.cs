using Capgemini.Domain.Commands;
using Capgemini.Domain.Interfaces.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Capgemini.Domain.Handlers
{
    public class UserHandler : IRequestHandler<UserCommand, string>
    {
        private readonly IMediator _mediator;
        private readonly IUserService _service;
        private readonly ILogService _logService;

        public Task<string> Handle(UserCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
