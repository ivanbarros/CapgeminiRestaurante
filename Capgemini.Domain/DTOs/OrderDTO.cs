using System;

namespace Capgemini.Domain.DTOs
{
    public class OrderDTO
    {
        //public int Id { get; set; }
        public int? IdFood { get; set; }
        public string Name { get; set; }
        public int TableNumber { get; set; }
        public DateTime OrderTime { get; set; }
        public decimal TotalPrice { get; set; }
        public string TypeFood { get; set; }
        public string SteakDone { get; set; }
        public int Quantity { get; set; }
        public DateTime CloseOrder { get; set; }
        public int IdWaiter { get; set; }
    }
}
