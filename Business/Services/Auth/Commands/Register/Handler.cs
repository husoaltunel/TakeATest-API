
using AutoMapper;
using Business.Constants;
using Business.Services.Auth.Commands.Register;
using Business.Services.User.Queries.GetUserByUsername;
using Core.DataAccess.Concrete;
using Core.Entities.Concrete;
using Core.Utilities.Hashing;
using Core.Utilities.Hashing.Abstract;
using Core.Utilities.Result;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;

using DataAccess.Utilities.UnitOfWork;
using Entities.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Managers.Auth.Commands.Register
{
    public class Handler : BaseConnection, IRequestHandler<RegisterCommand, IResult>
    {
        private IMediator _mediator;
        private IHashingHelper _hashingHelper;
        private readonly IMapper _mapper ;
        public Handler(IDbConnection dbConnection, IMediator mediator, IHashingHelper hashingHelper,IMapper mapper)
        {
            Connection = dbConnection;
            _mediator = mediator;
            _hashingHelper = hashingHelper;
            _mapper = mapper;
        }
        public async Task<IResult> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            using (var unitOfWork = UnitOfWorkUtil.GetUnitOfWork(Connection))
            {
                var user = await _mediator.Send(new GetUserByUserNameQuery() { Username = request.Username });
                if (ResultUtil<UserDto>.IsDataExist(user.Data))
                {
                    return new ErrorResult(message: AuthMessages.UserExist);
                }
                var passwordSalt = _hashingHelper.GeneratePasswordSalt();
                var passwordHash = _hashingHelper.GeneratePasswordHash(request.Password,passwordSalt);
                var newUser = _mapper.Map<User>(request); 
                newUser.PasswordHash = passwordHash;
                newUser.PasswordSalt = passwordSalt;
                var result = await unitOfWork.DbContext.Users.InsertAsync(newUser);
                if (!ResultUtil<int>.IsResultSuccees(result))
                {
                    return new ErrorResult();
                }
                return new SuccessResult();
            }

        }
    }
}
