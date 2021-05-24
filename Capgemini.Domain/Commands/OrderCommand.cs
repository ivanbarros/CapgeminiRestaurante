using Capgemini.Domain.Entities;
using MediatR;

namespace Capgemini.Domain.Commands
{
    public class OrderCommand : IRequest<string>
    {
        public virtual OrderEntity Orders { get; set; }
       

    }
}
