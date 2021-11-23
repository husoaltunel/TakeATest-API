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

      

    }
}
