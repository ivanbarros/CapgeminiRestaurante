using Capgemini.Data.Context;
using Capgemini.Domain.DTOs;
using Capgemini.Domain.Entities;
using Capgemini.Domain.Interfaces.Repositories;
using Capgemini.Domain.UnitOfWork;
using Dapper;
using System.Collections.Generic;
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

       

        public async Task<FoodDTO> GetFoodById(int idFood)
        {
            
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

        public async Task Insert(string query, object param = null)
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

        public Task<int> InsertIdentityTable<T>(T table) where T : class
        {
            throw new System.NotImplementedException();
        }

        public Task<T> InsertIdentityTable<T>(string query, object param = null)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> InsertIdentityTable(string query, object param = null)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<T>> InsertManyIdentityTable<T>(string query, object param = null)
        {
            throw new System.NotImplementedException();
        }

        public async Task<T> ById<T>(int id) where T : class
        {

            var result = await _unitOfWork.Connection.QueryFirstOrDefaultAsync<FoodDTO>($@"
                SELECT * FROM food where Id = @idFood;"
              , new
              {
                  id
              }
               , commandType: CommandType.Text, transaction: _unitOfWork.Transaction);

            return result;
        }

        public Task<IEnumerable<T>> All<T>() where T : class
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<T>> FindSimple<T>(string query, object param = null)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<T>> Find<T>(string tableName, string columnName, object columnValue) where T : class
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<T>> FindByQuery<T>(string query, object param = null) where T : class
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<T1>> FindByQuery<T1, T2>(string query, System.Func<T1, T2, T1> func = null, object param = null)
            where T1 : class
            where T2 : class
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<T1>> FindByQuery<T1, T2, T3>(string query, System.Func<T1, T2, T3, T1> func = null, object param = null)
            where T1 : class
            where T2 : class
            where T3 : class
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<T1>> FindByQuery<T1, T2, T3, T4>(string query, System.Func<T1, T2, T3, T4, T1> func = null, object param = null)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<T1>> FindByQuery<T1, T2, T3, T4, T5>(string query, System.Func<T1, T2, T3, T4, T5, T1> func = null, object param = null)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
            where T5 : class
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<T1>> FindByQuery<T1, T2, T3, T4, T5, T6>(string query, System.Func<T1, T2, T3, T4, T5, T6, T1> func = null, object param = null)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
            where T5 : class
            where T6 : class
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<T1>> FindByQuery<T1, T2, T3, T4, T5, T6, T7>(string query, System.Func<T1, T2, T3, T4, T5, T6, T7, T1> func = null, object param = null)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
            where T5 : class
            where T6 : class
            where T7 : class
        {
            throw new System.NotImplementedException();
        }

        public Task<T> SingleSimple<T>(string query, object param = null)
        {
            throw new System.NotImplementedException();
        }

        public Task<T> SingleByQuery<T>(string query, object param = null) where T : class
        {
            throw new System.NotImplementedException();
        }

        public Task<T1> SingleByQuery<T1, T2>(string query, System.Func<T1, T2, T1> func = null, object param = null)
            where T1 : class
            where T2 : class
        {
            throw new System.NotImplementedException();
        }

        public Task<T1> SingleByQuery<T1, T2, T3>(string query, System.Func<T1, T2, T3, T1> func = null, object param = null)
            where T1 : class
            where T2 : class
            where T3 : class
        {
            throw new System.NotImplementedException();
        }

        public Task<T1> SingleByQuery<T1, T2, T3, T4>(string query, System.Func<T1, T2, T3, T4, T1> func = null, object param = null)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
        {
            throw new System.NotImplementedException();
        }

        public Task<T1> SingleByQuery<T1, T2, T3, T4, T5>(string query, System.Func<T1, T2, T3, T4, T5, T1> func = null, object param = null)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
            where T5 : class
        {
            throw new System.NotImplementedException();
        }

        public Task<T1> SingleByQuery<T1, T2, T3, T4, T5, T6>(string query, System.Func<T1, T2, T3, T4, T5, T6, T1> func = null, object param = null)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
            where T5 : class
            where T6 : class
        {
            throw new System.NotImplementedException();
        }

        public Task<T1> SingleByQuery<T1, T2, T3, T4, T5, T6, T7>(string query, System.Func<T1, T2, T3, T4, T5, T6, T7, T1> func = null, object param = null)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
            where T5 : class
            where T6 : class
            where T7 : class
        {
            throw new System.NotImplementedException();
        }

        public Task Update(string query, object param = null)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete<T>(T entity) where T : class
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(string query, object param = null)
        {
            throw new System.NotImplementedException();
        }
    }
}

