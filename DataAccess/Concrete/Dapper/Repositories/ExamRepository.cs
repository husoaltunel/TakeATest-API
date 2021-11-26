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
    public class ExamRepository : DapperBaseRepository<Exam>, IExamRepository
    {

        public ExamRepository(IDbConnection dbConnection,IDbTransaction transaction) : base(dbConnection,transaction)
        {
   
        }
        public override async Task<IEnumerable<Exam>> GetAllAsync()
        {
            return await Connection.QueryAsync<Exam>($@"select * from ""Exams"" where (IsActive = 1) ", transaction: Transaction);
        }
        public override async Task<Exam> GetByIdAsync(long id)
        {

            return await Connection.QuerySingleOrDefaultAsync<Exam>($@"select * from ""Exams"" where (Id = @id) and (IsActive = 1) ", new { id }, transaction: Transaction);
        }
        public override async Task<long> DeleteAsync(long id)
        {
            return await Connection.ExecuteAsync($@"update ""Exams"" set IsActive = 0 where (Id = @id)", new { id = id }, transaction: Transaction);
        }

    }
}
