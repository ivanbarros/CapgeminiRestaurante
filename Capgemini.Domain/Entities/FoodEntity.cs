using Capgemini.Domain.Constantes;
using Capgemini.Domain.Entities.Base;
using Capgemini.Domain.Enums;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace Capgemini.Domain.Entities
{
    public class FoodEntity : BaseEntity
    {
        private string name;

        [Required, SwaggerSchema(FoodConstant.NAME_REQUIRED, Format = "")]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private decimal price;

        [Required, SwaggerSchema(FoodConstant.PRICE_REQUIRED, Format = "")]
        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }
        
        [Required, SwaggerSchema(FoodConstant.TYPE_REQUIRED, Format = "")]
        public FoodEnum TypeFood { get; set; }

        [Required, SwaggerSchema(FoodConstant.TASTE_REQUIRED, Format = "")]
        public TasteEnum Taste { get; set; }

        [Required, SwaggerSchema(FoodConstant.TEMPERATURE_REQUIRED, Format = "")]
        public Temperature Temperature { get; set; }

       
    }
}
