using System.ComponentModel.DataAnnotations;

namespace Capgemini.Domain.DTOs
{
    public class FoodDTO
    {
        public int Id { get; set; }
        [Required]
        public string FoodNames { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string Type { get; set; }
        public string Taste { get; set; }
        public string Temperature { get; set; }
    }
}
