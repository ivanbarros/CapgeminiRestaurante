using Capgemini.Domain.Interfaces.Repositories;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Capgemini.Infra.Repositories
{
    public class BaseRepository : IBaseRepository
    {
        public IDbConnection _dbConnection { get; private set; }

        public IDbTransaction _dbTransaction { get; set; }

        public BaseRepository(IDbConnection dbConnection, IDbTransaction dbTransaction)
        {
            _dbConnection = dbConnection;
            _dbTransaction = dbTransaction;
        }

        #region Create Methods

        public async Task Insert(string query, object param = null)
        {
            await _dbConnection.QueryAsync(query, param: param, transaction: _dbTransaction);
        }

        public async Task<int> InsertIdentityTable<T>(T table) where T : class
        {
            var id = await _dbConnection.InsertAsync(table);

            return id;
        }

        public async Task<T> InsertIdentityTable<T>(string query, object param = null)
        {
            var returnObj = (await _dbConnection.QueryAsync<T>(query, param: param, transaction: _dbTransaction)).Single();

            return returnObj;
        }

        public async Task<IEnumerable<T>> InsertManyIdentityTable<T>(string query, object param = null)
        {

            var returnObjs = await _dbConnection.ExecuteAsync(query, param);

            return null;
        }

        public async Task<int> InsertIdentityTable(string query, object param = null)
        {
            var id = (await _dbConnection.QueryAsync<int>(query, param: param, transaction: _dbTransaction)).Single();

            return id;
        }

        #endregion Create Methods

        #region Read Methods

        public async Task<T> ById<T>(int id) where T : class =>
            await _dbConnection.GetAsync<T>(id);

        public async Task<IEnumerable<T>> All<T>() where T : class =>
            await _dbConnection.GetAllAsync<T>();

        public async Task<IEnumerable<T>> FindSimple<T>(string query, object param = null)
        {
            return await _dbConnection.QueryAsync<T>
            (
                query,
                param: param, transaction: _dbTransaction
            );
        }

        public async Task<IEnumerable<T>> Find<T>(string tableName, string columnName, object columnValue) where T : class
        {
            return await _dbConnection.QueryAsync<T>
            (
                $"SELECT * FROM {tableName} WHERE {columnName} = @KeyValue",
                param: new { KeyValue = columnValue },
                transaction: _dbTransaction
            );
        }

        public async Task<IEnumerable<T>> FindByQuery<T>(string query, object param = null) where T : class
        {
            return await _dbConnection.QueryAsync<T>
            (
                query,
                param: param, transaction: _dbTransaction
            );
        }

        public async Task<IEnumerable<T1>> FindByQuery<T1, T2>(string query, Func<T1, T2, T1> func = null, object param = null)
            where T1 : class
            where T2 : class
        {
            return await _dbConnection.QueryAsync<T1, T2, T1>(
                query,
                (t1, t2) =>
                {
                    if (func != null)
                        return func.Invoke(t1, t2);

                    t1.GetType().GetProperty(typeof(T2).Name).SetValue(t1, t2);
                    return t1;
                },
                param: param, transaction: _dbTransaction
                );
        }

        public async Task<IEnumerable<T1>> FindByQuery<T1, T2, T3>(string query, Func<T1, T2, T3, T1> func = null, object param = null)
            where T1 : class
            where T2 : class
            where T3 : class
        {
            return await _dbConnection.QueryAsync<T1, T2, T3, T1>(
                query,
                (t1, t2, t3) =>
                {
                    if (func != null)
                        return func.Invoke(t1, t2, t3);

                    t1.GetType().GetProperty(typeof(T2).Name).SetValue(t1, t2);
                    t1.GetType().GetProperty(typeof(T3).Name).SetValue(t1, t3);
                    return t1;
                },
                param: param, transaction: _dbTransaction
                );
        }

        public async Task<IEnumerable<T1>> FindByQuery<T1, T2, T3, T4>(string query, Func<T1, T2, T3, T4, T1> func = null, object param = null)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
        {
            return await _dbConnection.QueryAsync<T1, T2, T3, T4, T1>(
                query,
                (t1, t2, t3, t4) =>
                {
                    if (func != null)
                        return func.Invoke(t1, t2, t3, t4);

                    t1.GetType().GetProperty(typeof(T2).Name).SetValue(t1, t2);
                    t1.GetType().GetProperty(typeof(T3).Name).SetValue(t1, t3);
                    t1.GetType().GetProperty(typeof(T4).Name).SetValue(t1, t4);
                    return t1;
                },
                param: param, transaction: _dbTransaction
                );
        }

        public async Task<IEnumerable<T1>> FindByQuery<T1, T2, T3, T4, T5>(string query, Func<T1, T2, T3, T4, T5, T1> func = null, object param = null)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
            where T5 : class
        {
            return await _dbConnection.QueryAsync<T1, T2, T3, T4, T5, T1>(
               query,
               (t1, t2, t3, t4, t5) =>
               {
                   if (func != null)
                       return func.Invoke(t1, t2, t3, t4, t5);

                   t1.GetType().GetProperty(typeof(T2).Name).SetValue(t1, t2);
                   t1.GetType().GetProperty(typeof(T3).Name).SetValue(t1, t3);
                   t1.GetType().GetProperty(typeof(T4).Name).SetValue(t1, t4);
                   t1.GetType().GetProperty(typeof(T5).Name).SetValue(t1, t5);
                   return t1;
               },
               param: param, transaction: _dbTransaction
               );
        }

        public async Task<IEnumerable<T1>> FindByQuery<T1, T2, T3, T4, T5, T6>(string query, Func<T1, T2, T3, T4, T5, T6, T1> func = null, object param = null)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
            where T5 : class
            where T6 : class
        {
            return await _dbConnection.QueryAsync<T1, T2, T3, T4, T5, T6, T1>(
               query,
               (t1, t2, t3, t4, t5, t6) =>
               {
                   if (func != null)
                       return func.Invoke(t1, t2, t3, t4, t5, t6);

                   t1.GetType().GetProperty(typeof(T2).Name).SetValue(t1, t2);
                   t1.GetType().GetProperty(typeof(T3).Name).SetValue(t1, t3);
                   t1.GetType().GetProperty(typeof(T4).Name).SetValue(t1, t4);
                   t1.GetType().GetProperty(typeof(T5).Name).SetValue(t1, t5);
                   t1.GetType().GetProperty(typeof(T6).Name).SetValue(t1, t6);
                   return t1;
               },
               param: param, transaction: _dbTransaction
               );
        }

        public async Task<IEnumerable<T1>> FindByQuery<T1, T2, T3, T4, T5, T6, T7>(string query, Func<T1, T2, T3, T4, T5, T6, T7, T1> func = null, object param = null)
           where T1 : class
           where T2 : class
           where T3 : class
           where T4 : class
           where T5 : class
           where T6 : class
           where T7 : class
        {
            return await _dbConnection.QueryAsync<T1, T2, T3, T4, T5, T6, T7, T1>(
               query,
               (t1, t2, t3, t4, t5, t6, t7) =>
               {
                   if (func != null)
                       return func.Invoke(t1, t2, t3, t4, t5, t6, t7);

                   t1.GetType().GetProperty(typeof(T2).Name).SetValue(t1, t2);
                   t1.GetType().GetProperty(typeof(T3).Name).SetValue(t1, t3);
                   t1.GetType().GetProperty(typeof(T4).Name).SetValue(t1, t4);
                   t1.GetType().GetProperty(typeof(T5).Name).SetValue(t1, t5);
                   t1.GetType().GetProperty(typeof(T6).Name).SetValue(t1, t6);
                   t1.GetType().GetProperty(typeof(T7).Name).SetValue(t1, t7);
                   return t1;
               },
               param: param, transaction: _dbTransaction
               );
        }

        public async Task<T> SingleSimple<T>(string query, object param = null)
        {
            return (await FindSimple<T>(query, param: param)).FirstOrDefault();
        }

        public async Task<T> SingleByQuery<T>(string query, object param = null) where T : class
        {
            return await _dbConnection.QuerySingleOrDefaultAsync<T>
            (
                query,
                param: param, transaction: _dbTransaction

            );
        }

        public async Task<T1> SingleByQuery<T1, T2>(string query, Func<T1, T2, T1> func = null, object param = null)
            where T1 : class
            where T2 : class
        {
            return (await FindByQuery(query, func: func, param: param)).FirstOrDefault();
        }

        public async Task<T1> SingleByQuery<T1, T2, T3>(string query, Func<T1, T2, T3, T1> func = null, object param = null)
            where T1 : class
            where T2 : class
            where T3 : class
        {
            return (await FindByQuery(query, func: func, param: param)).FirstOrDefault();
        }

        public async Task<T1> SingleByQuery<T1, T2, T3, T4>(string query, Func<T1, T2, T3, T4, T1> func = null, object param = null)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
        {
            return (await FindByQuery(query, func: func, param: param)).FirstOrDefault();
        }

        public async Task<T1> SingleByQuery<T1, T2, T3, T4, T5>(string query, Func<T1, T2, T3, T4, T5, T1> func = null, object param = null)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
            where T5 : class
        {
            return (await FindByQuery(query, func: func, param: param)).FirstOrDefault();
        }

        public async Task<T1> SingleByQuery<T1, T2, T3, T4, T5, T6>(string query, Func<T1, T2, T3, T4, T5, T6, T1> func = null, object param = null)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
            where T5 : class
            where T6 : class
        {
            return (await FindByQuery(query, func: func, param: param)).FirstOrDefault();
        }

        public async Task<T1> SingleByQuery<T1, T2, T3, T4, T5, T6, T7>(string query, Func<T1, T2, T3, T4, T5, T6, T7, T1> func = null, object param = null)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
            where T5 : class
            where T6 : class
            where T7 : class
        {
            return (await FindByQuery(query, func: func, param: param)).FirstOrDefault();
        }

        #endregion Read Methods

        #region Update Methods

        public async Task Update(string query, object param = null)
        {
            await _dbConnection.QueryAsync(query, param: param, transaction: _dbTransaction);
        }

        #endregion Update Methods

        #region Delete Methods

        public async Task Delete<T>(T entity) where T : class
        {
            await _dbConnection.DeleteAsync(entity);
        }

        public async Task Delete(string query, object param = null)
        {
            await _dbConnection.QueryAsync(query, param: param, transaction: _dbTransaction);
        }

        #endregion Delete Methods
    }
}
