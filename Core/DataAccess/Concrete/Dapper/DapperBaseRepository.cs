using Core.DataAccess.Abstract;
using Core.Entities.Abstract;
using Core.Utilities.Sql;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.Concrete.Dapper
{
    public class DapperBaseRepository<TEntity> : BaseConnection, IRepository<TEntity> where TEntity : IEntity, new()
    {
        private string entityName;
        public DapperBaseRepository(IDbConnection dbConnection, IDbTransaction transaction)
        {
            Connection = dbConnection;
            Transaction = transaction;
            entityName = typeof(TEntity).Name;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await Connection.QueryAsync<TEntity>($@"select * from ""{entityName}s"" ",transaction:Transaction);
        }

        public async Task<IEnumerable<TEntity>> GetByFilterAsync(Func<TEntity, bool> filter)
        {
            return await Task.FromResult(GetAllAsync().Result.Where(filter));
        }
        public async Task<TEntity> GetByIdAsync(long id)
        {

            return await Connection.QuerySingleOrDefaultAsync<TEntity>($@"select * from ""{entityName}s"" where ""Id"" = @id", new { id }, transaction: Transaction);
        }
        public async Task<long> InsertAsync(TEntity entity)
        {
            return await Connection.QuerySingleAsync<long>(SqlQueryUtil<TEntity>.GenerateGenericInsertQuery(entity, entityName), entity, transaction: Transaction);
        }

        public async Task<long> UpdateAsync(TEntity entity)
        {
            return await Connection.QuerySingleAsync<long>(SqlQueryUtil<TEntity>.GenerateGenericUpdateQuery(entity, entityName), entity, transaction: Transaction);
        }
        public async Task<long> DeleteAsync(long id)
        {
            return await Connection.ExecuteAsync($@"delete from ""{entityName}s"" where ""Id"" = @id",new {id=id }, transaction: Transaction);
        }

    }
}
