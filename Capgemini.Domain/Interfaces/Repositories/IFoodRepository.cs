using Capgemini.Domain.DTOs;
using Capgemini.Domain.Entities;
using System.Threading.Tasks;

namespace Capgemini.Domain.Interfaces.Repositories
{
    public interface IFoodRepository
    {
        Task<FoodDTO> GetFoodById(int idFood);
        Task<FoodDTO> GetFoodByName(string name);
        //Task Insert(FoodEntity foods);
        Task Insert(FoodDTO foods);
    }
}
