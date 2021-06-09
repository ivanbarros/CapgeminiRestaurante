using Capgemini.Domain.Enums;
using MediatR;

namespace Capgemini.Domain.Commands
{

    public class FoodCommand : IRequest<string>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public FoodEnum Type { get; set; }
        public TasteEnum Taste { get; set; }
        public Temperature Temperature { get; set; }
    }
}