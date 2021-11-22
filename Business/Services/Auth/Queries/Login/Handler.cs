using AutoMapper;
using Business.Constants;
using Core.DataAccess.Concrete;
using Core.Entities.Concrete;
using Core.Utilities.Hashing.Abstract;
using Core.Utilities.Result;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using Core.Utilities.Security.Abstract;
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

namespace Business.Services.Auth.Queries.Login
{
    public class Handler : BaseConnection, IRequestHandler<LoginQuery, IDataResult<LoginInfoDto>>
    {
        private readonly IMediator _mediator;
        private readonly ITokenHelper _tokenHelper;
        private readonly IHashingHelper _hashingHelper;
        private readonly IMapper _mapper;
        public Handler(IMediator mediator, ITokenHelper tokenHelper, IDbConnection connection, IHashingHelper hashingHelper, IMapper mapper)
        {
            _mediator = mediator;
            _tokenHelper = tokenHelper;
            Connection = connection;
            _hashingHelper = hashingHelper;
            _mapper = mapper;
        }

        public async Task<IDataResult<LoginInfoDto>> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            using (var unitOfWork = UnitOfWorkUtil.GetUnitOfWork(Connection))
            {
                var result = await unitOfWork.DbContext.Users.GetByFilterAsync(user => user.Username == request.Username);
                var user = result.FirstOrDefault();
                if (!ResultUtil<Core.Entities.Concrete.User>.IsDataExist(user))
                {
                    return new ErrorDataResult<LoginInfoDto>(message: AuthMessages.UserNotFound);
                }
                if (!_hashingHelper.VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
                {
                    return new ErrorDataResult<LoginInfoDto>(message: AuthMessages.InvalidPassword);
                };
                var roles = await unitOfWork.DbContext.Roles.GetRolesByUserId(user.Id);
                var operationClaims = await unitOfWork.DbContext.OperationClaims.GetOperationClaimsByUserId(user.Id);
                var loginInfo = new LoginInfoDto()
                {
                    Username = user.Username,
                    AccessToken = _tokenHelper.CreateToken(user, operationClaims.ToList(), roles.ToList())
                };


                return new SuccessDataResult<LoginInfoDto>(loginInfo);
            }
        }
    }
}
