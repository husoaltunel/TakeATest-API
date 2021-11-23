using Core.DataAccess.Concrete.Dapper;
using Core.Entities.Concrete;
using Dapper;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Dapper.Repositories
{
    public class RoleRepository : DapperBaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(IDbConnection dbConnection, IDbTransaction transaction) : base(dbConnection,transaction)
        {

        }
        public async Task<IEnumerable<Role>> GetRolesByUserId(long id)
        {
            return await Connection.QueryAsync<Role>("select Name from Roles inner join UserRoles on UserRoles.RoleId = Roles.Id where UserRoles.UserId = @id",new {id = id });
        }
    }
}
