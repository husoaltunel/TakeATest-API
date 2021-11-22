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
        public DapperBaseRepository(IDbConnection dbConnection)
        {
            Connection = dbConnection;
            entityName = typeof(TEntity).Name;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await Connection.QueryAsync<TEntity>($@"select * from ""{entityName}s"" ");
        }

        public async Task<IEnumerable<TEntity>> GetByFilterAsync(Func<TEntity, bool> filter)
        {
            return await Task.FromResult(GetAllAsync().Result.Where(filter));
        }
        public async Task<TEntity> GetByIdAsync(long id)
        {

            return await Connection.QuerySingleOrDefaultAsync<TEntity>($@"select * from ""{entityName}s"" where ""Id"" = id", new { id });
        }
        public async Task<int> InsertAsync(TEntity entity)
        {
            return await Connection.ExecuteAsync(SqlQueryUtil<TEntity>.GenerateGenericInsertQuery(entity, entityName), entity);
        }

        public async Task<int> UpdateAsync(TEntity entity)
        {
            return await Connection.ExecuteAsync(SqlQueryUtil<TEntity>.GenerateGenericUpdateQuery(entity, entityName), entity);
        }
        public async Task<int> DeleteAsync(long id)
        {
            return await Connection.ExecuteAsync($@"delete from ""{entityName}s"" where ""Id"" = {id}");
        }

    }
}
