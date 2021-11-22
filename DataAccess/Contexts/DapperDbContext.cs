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
        public DapperDbContext(IDbConnection dbConnection)
        {
            Connection = dbConnection;
        }
        public UserRepository Users => new UserRepository(Connection);
        public ExamRepository Exams => new ExamRepository(Connection);
        public OperationClaimRepository OperationClaims => new OperationClaimRepository(Connection);
        public RoleRepository Roles => new RoleRepository(Connection);
        public QuestionRepository Questions => new QuestionRepository(Connection);
        public OptionRepository Options => new OptionRepository(Connection);



    }
}
