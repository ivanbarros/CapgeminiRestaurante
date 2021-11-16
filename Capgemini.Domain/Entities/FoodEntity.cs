using Capgemini.Domain.Constantes;
using Capgemini.Domain.Entities.Base;
using Capgemini.Domain.Enums;
using MongoDB.Bson.Serialization.Attributes;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace Capgemini.Domain.Entities
{
    public class FoodEntity : BaseEntity
    {
        private string name;

        [Required, SwaggerSchema(FoodConstant.NAME_REQUIRED, Format = "")]
        [BsonElement("name")]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private decimal price;

        [Required, SwaggerSchema(FoodConstant.PRICE_REQUIRED, Format = "")]
        [BsonElement("price")]
        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }

        [Required]
        [SwaggerSchema(FoodConstant.TYPE_REQUIRED, Format = "")]
        [BsonElement("foodType")]
        public FoodEnum TypeFood { get; set; }

        [Required, SwaggerSchema(FoodConstant.TASTE_REQUIRED, Format = "")]
        [BsonElement("foodTaste")]
        public TasteEnum Taste { get; set; }


        [Required, SwaggerSchema(FoodConstant.TEMPERATURE_REQUIRED, Format = "")]
        [BsonElement("foodTemperature")]
        public Temperature Temperature { get; set; }

        [BsonElement("quantity")]
        public int Quantity { get; set; }
        [BsonElement("SteakDone")]
        public SteakDone SteakDone { get; set; }


    }
}
