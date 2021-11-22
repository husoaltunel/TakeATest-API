using Core.DataAccess.Concrete.Dapper;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DataAccess.Concrete.Dapper.Repositories
{
    public class UserRepository : DapperBaseRepository<User>, IUserRepository
    {
        public UserRepository(IDbConnection dbConnection) : base(dbConnection)
        {

        }
    }
}
