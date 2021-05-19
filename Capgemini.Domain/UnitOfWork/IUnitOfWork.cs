using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

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
