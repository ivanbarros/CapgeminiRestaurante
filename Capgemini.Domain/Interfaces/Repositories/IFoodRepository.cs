using Capgemini.Domain.DTOs;
using System.Threading.Tasks;

namespace Capgemini.Domain.Interfaces.Repositories
{
    public interface IFoodRepository
    {
        Task<FoodDTO> AddFoods(FoodDTO foods);
        Task<FoodDTO>GetFoodByName(string name);
        Task<FoodDTO>GetFoodById(int idFood);
    }
}
