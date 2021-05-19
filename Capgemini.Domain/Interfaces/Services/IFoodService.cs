using Capgemini.Domain.DTOs;
using Capgemini.Domain.Entities;
using System.Threading.Tasks;

namespace Capgemini.Domain.Interfaces.Services
{
    public interface IFoodService
    {
        Task <FoodDTO> GetFoodById(int id);
        Task<FoodDTO> AddFoods(FoodDTO foods);
        Task<FoodDTO> GetFoodByName(string food);
    }
}
