using Capgemini.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Capgemini.Domain.Interfaces.Repositories
{
    public interface IBaseRepository
    {
        IDbConnection _dbConnection { get; }
        IDbTransaction _dbTransaction { get; set; }

        #region Create Methods

        Task Insert(string query, object param = null);

        Task<int> InsertIdentityTable<T>(T table) where T : class;

        Task<T> InsertIdentityTable<T>(string query, object param = null);

        Task<int> InsertIdentityTable(string query, object param = null);
        Task<IEnumerable<T>> InsertManyIdentityTable<T>(string query, object param = null);

        #endregion

        #region Read Methods

        Task<T> ById<T>(int id) where T : class;

        Task<IEnumerable<T>> All<T>() where T : class;

        Task<IEnumerable<T>> FindSimple<T>(string query, object param = null);

        Task<IEnumerable<T>> Find<T>(string tableName, string columnName, object columnValue) where T : class;

        Task<IEnumerable<T>> FindByQuery<T>(string query, object param = null) where T : class;

        Task<IEnumerable<T1>> FindByQuery<T1, T2>(string query, Func<T1, T2, T1> func = null, object param = null)
            where T1 : class
            where T2 : class;

        Task<IEnumerable<T1>> FindByQuery<T1, T2, T3>(string query, Func<T1, T2, T3, T1> func = null, object param = null)
            where T1 : class
            where T2 : class
            where T3 : class;

        Task<IEnumerable<T1>> FindByQuery<T1, T2, T3, T4>(string query, Func<T1, T2, T3, T4, T1> func = null, object param = null)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class;

        Task<IEnumerable<T1>> FindByQuery<T1, T2, T3, T4, T5>(string query, Func<T1, T2, T3, T4, T5, T1> func = null, object param = null)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
            where T5 : class;

        Task<IEnumerable<T1>> FindByQuery<T1, T2, T3, T4, T5, T6>(string query, Func<T1, T2, T3, T4, T5, T6, T1> func = null, object param = null)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
            where T5 : class
            where T6 : class;

        Task<IEnumerable<T1>> FindByQuery<T1, T2, T3, T4, T5, T6, T7>(string query, Func<T1, T2, T3, T4, T5, T6, T7, T1> func = null, object param = null)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
            where T5 : class
            where T6 : class
            where T7 : class;

        Task<T> SingleSimple<T>(string query, object param = null);

        Task<T> SingleByQuery<T>(string query, object param = null) where T : class;

        Task<T1> SingleByQuery<T1, T2>(string query, Func<T1, T2, T1> func = null, object param = null)
            where T1 : class
            where T2 : class;

        Task<T1> SingleByQuery<T1, T2, T3>(string query, Func<T1, T2, T3, T1> func = null, object param = null)
            where T1 : class
            where T2 : class
            where T3 : class;

        Task<T1> SingleByQuery<T1, T2, T3, T4>(string query, Func<T1, T2, T3, T4, T1> func = null, object param = null)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class;

        Task<T1> SingleByQuery<T1, T2, T3, T4, T5>(string query, Func<T1, T2, T3, T4, T5, T1> func = null, object param = null)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
            where T5 : class;

        Task<T1> SingleByQuery<T1, T2, T3, T4, T5, T6>(string query, Func<T1, T2, T3, T4, T5, T6, T1> func = null, object param = null)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
            where T5 : class
            where T6 : class;

        Task<T1> SingleByQuery<T1, T2, T3, T4, T5, T6, T7>(string query, Func<T1, T2, T3, T4, T5, T6, T7, T1> func = null, object param = null)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
            where T5 : class
            where T6 : class
            where T7 : class;

        #endregion

        #region Update Methods

        Task Update(string query, object param = null);

        #endregion

        #region Delete Methods

        Task Delete<T>(T entity) where T : class;

        Task Delete(string query, object param = null);

        #endregion
    }
}