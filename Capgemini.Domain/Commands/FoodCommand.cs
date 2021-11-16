using Capgemini.Domain.Constantes;
using Capgemini.Domain.Enums;
using MediatR;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace Capgemini.Domain.Commands
{

    public class FoodCommand : IRequest<string>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        [Required, SwaggerSchema(FoodConstant.TYPE_REQUIRED, Format = "")]
        public FoodEnum Type { get; set; }
        public TasteEnum Taste { get; set; }
        public Temperature Temperature { get; set; }
    }
}