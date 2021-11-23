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
    public class QuestionRepository : DapperBaseRepository<Question>, IQuestionRepository
    {
        public QuestionRepository(IDbConnection dbConnection, IDbTransaction transaction) : base(dbConnection,transaction)
        {

        }
        public async Task<IEnumerable<Question>> GetQuestionsByExamId(long id)
        {
            return await Connection.QueryAsync<Question>("select * from Questions where ExamId = @id", new {id=id });
        }
    }
}
