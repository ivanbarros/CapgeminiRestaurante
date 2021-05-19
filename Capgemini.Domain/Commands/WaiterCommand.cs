using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capgemini.Domain.Commands
{
    public class WaiterCommand : IRequest<string>
    {
        public string Name { get; set; }
    }
}
