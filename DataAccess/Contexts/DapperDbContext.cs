using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.Dapper.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DataAccess.Contexts
{
    public class DapperDbContext : BaseConnection, IDbContext
    {
        public DapperDbContext(IDbConnection dbConnection,IDbTransaction transaction)
        {
            Connection = dbConnection;
            Transaction = transaction;
        }
        public UserRepository Users => new UserRepository(Connection,Transaction);
        public ExamRepository Exams => new ExamRepository(Connection, Transaction);
        public OperationClaimRepository OperationClaims => new OperationClaimRepository(Connection, Transaction);
        public RoleRepository Roles => new RoleRepository(Connection, Transaction);
        public QuestionRepository Questions => new QuestionRepository(Connection, Transaction);
        public OptionRepository Options => new OptionRepository(Connection, Transaction);



    }
}
