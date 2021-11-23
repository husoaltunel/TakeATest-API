using Core.DataAccess.Abstract;
using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using DataAccess.Contexts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DataAccess.UnitOfWorks
{
    public class DapperUnitOfWork : BaseConnection, IUnitOfWork, IDisposable
    {
        public DapperUnitOfWork(IDbConnection dbConnection)
        {
            Connection = dbConnection;
        }
        public DapperDbContext DbContext => new DapperDbContext(Connection, Transaction);

        public void OpenConnection()
        {
            if (Connection.State != ConnectionState.Open)
            {
                Connection.Open();
            }

        }
        public void BeginTransaction()
        {
            Transaction = Connection.BeginTransaction(IsolationLevel.ReadCommitted);
        }
        public void Commit()
        {
            Transaction.Commit();
        }
        public void Rollback()
        {
            Transaction.Rollback();
        }
        public void Dispose()
        {

        }
    }
}
