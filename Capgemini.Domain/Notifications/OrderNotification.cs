using Capgemini.Domain.Entities;
using Capgemini.Domain.Enums;
using MediatR;
using System;

namespace Capgemini.Domain.Notifications
{
    public class OrderNotification : INotification
    {
        
        public FoodEntity Food { get; set; }
        public int TableNumber { get; set; }
        public DateTime OrderTime { get; set; }
        public decimal TotalPrice { get; set; }
        public FoodEnum TypeFood { get; set; }
        public string SteakDone { get; set; }
        public DateTime CloseOrder { get; set; }
        public int IdWaiter { get; set; }
    }
}
