using Capgemini.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;

namespace Capgemini.Domain.Commands
{
    public class OrderCommand : IRequest<string>
    {
        public string Food { get; set; }
        public int TableNumber { get; set; }
        public FoodEnum typeFood { get; set; }
        public SteakDone SteakDone { get; set; }
        public int Quantity { get; set; }
        public int IdWaiter { get; set; }

    }
}
