using AutoMapper;
using Business.Services.Question.Queries.GetQuestionsByExamId;
using Core.DataAccess.Concrete;
using Core.Utilities.Result;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Utilities.UnitOfWork;
using Entities.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Services.Role.Queries.GetOperationClaimsByUserId
{
    public class Handler : BaseConnection, IRequestHandler<GetRolesByUserIdQuery, IDataResult<IEnumerable<RoleDto>>>
    {
        private readonly IMapper _mapper;
        public Handler(IDbConnection dbConnection, IMapper mapper)
        {
            Connection = dbConnection;
            _mapper = mapper;
        }
        public async Task<IDataResult<IEnumerable<RoleDto>>> Handle(GetRolesByUserIdQuery request, CancellationToken cancellationToken)
        {
            using (var unitOfWork = UnitOfWorkUtil.GetUnitOfWork(Connection))
            {
                var result = await unitOfWork.DbContext.Roles.GetRolesByUserId(request.Id);
                if (!ResultUtil<IEnumerable<Core.Entities.Concrete.Role>>.IsDataExist(result))
                {
                    return new ErrorDataResult<IEnumerable<RoleDto>>();
                }
                var mappedRoles = result.Select(role => _mapper.Map<RoleDto>(role));
                return new SuccessDataResult<IEnumerable<RoleDto>>(mappedRoles);
            }
        }
    }
}
