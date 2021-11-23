using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.Abstract
{
    public interface IRepository<TEntity>
    {
        public Task<IEnumerable<TEntity>> GetByFilterAsync(Func<TEntity,bool> filter);
        public Task<TEntity> GetByIdAsync(long id);
        public Task<IEnumerable<TEntity>> GetAllAsync();
        public Task<long> InsertAsync(TEntity entity);
        public Task<long> UpdateAsync(TEntity entity);
        public Task<long> DeleteAsync(long id);
    }
}
