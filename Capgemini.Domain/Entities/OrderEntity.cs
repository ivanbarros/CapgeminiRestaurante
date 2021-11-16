using Capgemini.Domain.Entities.Base;
using Capgemini.Domain.Enums;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace Capgemini.Domain.Entities
{
    
    public class OrderEntity : BaseEntity
    {
        [BsonElement("foods")]
        public List<FoodEntity> Foods { get; set; }

        
        public int? IdFood { get; set; }

        private int tableNumber;

        public int TableNumber
        {
            get { return tableNumber; }
            set { tableNumber = value; }
        }

        private DateTime orderTime;
        public DateTime OrderTime 
        {
            get { return orderTime; }
            set { orderTime = value; }
        }
        private decimal totalPrice;

        public decimal TotalPrice
        {
            get { return totalPrice; }
            set { totalPrice = value; }
        }
        
        
        private int quantity;

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        private DateTime closeOrder;

        public DateTime CloseOrder
        {
            get { return closeOrder; }
            set { closeOrder = value; }
        }

        public WaiterEntity Waiter { get; set; }
        public int IdWaiter { get; set; }

        private UserEntity User;

        public UserEntity user
        {
            get { return User; }
            set { User = value; }
        }


    }
}
