﻿using Capgemini.Data.Context;
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
        MongoDbContext dbContext = new MongoDbContext();
        public async Task<FoodDTO> AddFoods(FoodDTO foods)
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
            taste = taste.ToString();
            var comida = new FoodEntity
            {
              Name = foods.Name,
              Price = foods.Price,
              Taste = Domain.Enums.TasteEnum.amargo,
              Quantity = 2,
              TypeFood = Domain.Enums.FoodEnum.grelhado,
              SteakDone = Domain.Enums.SteakDone.cru,
              Temperature = Domain.Enums.Temperature.quente
            };
            await dbContext.Foods.InsertOneAsync(comida);
            return foods;

        }

        public async Task<FoodDTO> GetFoodById(int idFood)
        {
            var result = await _unitOfWork.Connection.QueryFirstOrDefaultAsync<FoodDTO>($@"
                SELECT * FROM food where Id = @idFood;"
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
                SELECT * FROM food where Name = @name;"
              , new
              {
                  name
              }
               , commandType: CommandType.Text, transaction: _unitOfWork.Transaction);

            return result;
        }

    }
}

