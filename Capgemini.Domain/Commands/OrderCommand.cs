using Capgemini.Domain.Entities;
using Capgemini.Domain.Enums;
using MediatR;
using System;

namespace Capgemini.Domain.Commands
{
    public class OrderCommand : IRequest<string>
    {
       
        //public int? IdFood { get; set; }
        public string Food { get; set; }
        public int TableNumber { get; set; }
        public  DateTime OrderTime { get; set; }
        public decimal TotalPrice { get; set; }
        public FoodEnum typeFood { get; set; }
        public FoodEnum SteakDone { get; set; }
        public int Quantity { get; set; }
        public DateTime CloseOrder { get; set; }
        public int IdWaiter { get; set; }
    }
}
