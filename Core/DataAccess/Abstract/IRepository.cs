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
        public Task<int> InsertAsync(TEntity entity);
        public Task<int> UpdateAsync(TEntity entity);
        public Task<int> DeleteAsync(long id);
    }
}
