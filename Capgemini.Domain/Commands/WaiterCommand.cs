using MediatR;

namespace Capgemini.Domain.Commands
{
    public class WaiterCommand : IRequest<string>
    {
        public string Name { get; set; }
    }
}
