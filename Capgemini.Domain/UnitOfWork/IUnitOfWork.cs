using System;
using System.Data;

namespace Capgemini.Domain.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {

        IDbConnection Connection { get; }
        IDbTransaction Transaction { get; }
        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}
