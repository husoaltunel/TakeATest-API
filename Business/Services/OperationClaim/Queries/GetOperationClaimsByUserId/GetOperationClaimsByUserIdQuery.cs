using Core.Utilities.Result.Abstract;
using Entities.Dtos;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Business.Services.OperationClaim.Queries.GetOperationClaimsByUserId
{
    public class GetOperationClaimsByUserIdQuery : IRequest<IDataResult<IEnumerable<OperationClaimDto>>>
    {
        public long Id { get; set; }
    }
}
