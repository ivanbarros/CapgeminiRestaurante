using Capgemini.Domain.DTOs;
using Capgemini.Domain.Entities;
using Capgemini.Domain.Interfaces.Repositories;
using Capgemini.Domain.UnitOfWork;
using Dapper;
using System.Data;
using System.Threading.Tasks;

namespace Capgemini.Infra.Repositories
{
    public class FoodRepository : IFoodRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public FoodRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<FoodDTO> AddFoods(FoodDTO foods)
        {
            await _unitOfWork.Connection.ExecuteAsync($@"INSERT INTO testebd_.food
                            (
                            Name,
                            Price,
                            Type,
                            Taste,
                            Temperature)
                            VALUES
                            (
                            @Name,
                            @Price,
                            @Type,
                            @Taste,
                            @Temperature);
                            "
            , foods
         , commandType: CommandType.Text, transaction: _unitOfWork.Transaction);
            return foods;

        }

        public async Task<FoodDTO> GetFoodById(int idFood)
        {
            var result = await _unitOfWork.Connection.QueryFirstOrDefaultAsync<FoodDTO>($@"
                SELECT * FROM testebd_.food where Id = @idFood;"
              , new
              {
                  idFood
              }
               , commandType: CommandType.Text, transaction: _unitOfWork.Transaction);

            return result;
        }
    

        public async Task<FoodDTO> GetFoodByName(string name)
        {
            var result = await _unitOfWork.Connection.QueryFirstOrDefaultAsync<FoodDTO>($@"
                SELECT * FROM testebd_.food where Name = @name;"
              , new
              {
                  name
              }
               , commandType: CommandType.Text, transaction: _unitOfWork.Transaction);

            return result;
        }

    }
}

