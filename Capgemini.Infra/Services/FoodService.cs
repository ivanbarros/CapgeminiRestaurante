using Capgemini.Domain.DTOs;
using Capgemini.Domain.Interfaces.Repositories;
using Capgemini.Domain.Interfaces.Services;
using System.Threading.Tasks;

namespace Capgemini.Infra.Services
{
    public class FoodService : IFoodService
    {
        private readonly IFoodRepository _repository;
        
        public FoodService(IFoodRepository repository)
        {
            _repository = repository;
            
        }

        public async Task<FoodDTO> AddFoods(FoodDTO foods)
        {
            await _repository.Insert(foods);
           
            return foods;

        }

        public async Task<FoodDTO> GetFoodById(int id)
        {
            var result = await _repository.GetFoodById(id);
            return result;
        }

        public async Task<FoodDTO> GetFoodByName(string food)
        {
            var result = await _repository.GetFoodByName(food);
            return result;
        }
    }
}
