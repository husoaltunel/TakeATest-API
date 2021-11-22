using Core.DataAccess.Concrete.Dapper;
using Dapper;
using DataAccess.Abstract;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Dapper.Repositories
{
    public class OptionRepository : DapperBaseRepository<Option> , IOptionRepository
    {
        public OptionRepository(IDbConnection dbConnection) : base(dbConnection)
        {

        }

        public async Task<IEnumerable<Option>> GetOptionsByQuestionId(long id)
        {
            return await Connection.QueryAsync<Option>("select * from Options where QuestionId = @id",new{id=id });
        }
    }
}
