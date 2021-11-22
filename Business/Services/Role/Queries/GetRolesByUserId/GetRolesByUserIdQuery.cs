using Core.Utilities.Result.Abstract;
using Entities.Dtos;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Business.Services.Role.Queries.GetOperationClaimsByUserId
{
    public class GetRolesByUserIdQuery : IRequest<IDataResult<IEnumerable<RoleDto>>>
    {
        public long Id { get; set; }
    }
}
