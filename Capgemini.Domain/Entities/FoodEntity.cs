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

        [BsonElement("price")]
        [Required, SwaggerSchema(FoodConstant.PRICE_REQUIRED, Format = "")]
        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }

        [BsonElement("foodType")]
        
        [Required, SwaggerSchema(FoodConstant.TYPE_REQUIRED, Format = "")]
        public FoodEnum TypeFood { get; set; }

        [BsonElement("foodTaste")]

        [Required, SwaggerSchema(FoodConstant.TASTE_REQUIRED, Format = "")]
        public TasteEnum Taste { get; set; }

        [BsonElement("foodTemperature")]

        [Required, SwaggerSchema(FoodConstant.TEMPERATURE_REQUIRED, Format = "")]
        public Temperature Temperature { get; set; }

        [BsonElement("quantity")]
        public int Quantity { get; set; }
        [BsonElement("SteakDone")]
        public SteakDone SteakDone { get; set; }


    }
}
