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
    public class OperationClaimRepository : DapperBaseRepository<OperationClaim>, IOperationClaimRepository
    {
        public OperationClaimRepository(IDbConnection dbConnection) : base(dbConnection)
        {

        }

        public async Task<IEnumerable<OperationClaim>> GetOperationClaimsByUserId(long id)
        {
            return await Connection.QueryAsync<OperationClaim>("select Name from OperationClaims inner join UserOperationClaims on OperationClaims.Id = UserOperationClaims.OperationClaimId where UserOperationClaims.UserId = @id",new {id = id });
        }
    }
}
