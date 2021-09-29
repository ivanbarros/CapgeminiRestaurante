using Capgemini.Data.Context;
using Capgemini.Domain.DTOs;
using Capgemini.Domain.Entities;
using Capgemini.Domain.Interfaces.Repositories;
using Capgemini.Domain.UnitOfWork;
using Dapper;
using MongoDB.Driver;
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
        MongoDbContext dbContext = new MongoDbContext();

        public IDbConnection _dbConnection => throw new System.NotImplementedException();

        public IDbTransaction _dbTransaction { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

       

        public  Task<FoodDTO> GetFoodById(int idFood)
        {
            throw new System.NotImplementedException();
        }


        public async Task <FoodDTO> GetFoodByName(string FoodName)
        {
            var result = await _unitOfWork.Connection.QueryFirstOrDefaultAsync<FoodDTO>($@"
                SELECT * FROM food where Name = @name;"
              , new
              {
                  FoodName
              }
               , commandType: CommandType.Text, transaction: _unitOfWork.Transaction);
            var resultado = await dbContext.Foods.FindAsync(filter => FoodName.Equals(filter.Name));
            return result;
        }

        public async Task Insert(FoodDTO foods)
        {
            await _unitOfWork.Connection.ExecuteAsync($@"INSERT INTO food
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
            var taste = foods.Taste;
            taste.ToString();
            var comida = new FoodEntity
            {
                Name = foods.FoodNames,
                Price = foods.Price,
                Taste = Domain.Enums.TasteEnum.amargo,
                Quantity = 2,
                TypeFood = Domain.Enums.FoodEnum.grelhado,
                SteakDone = Domain.Enums.SteakDone.cru,
                Temperature = Domain.Enums.Temperature.quente
            };
            await dbContext.Foods.InsertOneAsync(comida);
             await Task.FromResult("");
        }
    }
}

