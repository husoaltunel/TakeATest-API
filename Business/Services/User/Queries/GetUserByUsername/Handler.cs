using AutoMapper;
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

namespace Business.Services.User.Queries.GetUserByUsername
{
    public class Handler : BaseConnection, IRequestHandler<GetUserByUserNameQuery, IDataResult<UserDto>>
    {
        private IMapper _mapper;
        public Handler(IDbConnection connection, IMapper mapper)
        {
            Connection = connection;
            _mapper = mapper;
        }
        public async Task<IDataResult<UserDto>> Handle(GetUserByUserNameQuery request, CancellationToken cancellationToken)
        {
            using (var unitOfWork = UnitOfWorkUtil.GetUnitOfWork(Connection))
            {
                var result = await unitOfWork.DbContext.Users.GetByFilterAsync(user => user.Username == request.Username.ToLower());
                var user = result.FirstOrDefault();
                if (ResultUtil<Core.Entities.Concrete.User>.IsDataExist(user))
                {
                    return new SuccessDataResult<UserDto>(_mapper.Map<UserDto>(user));
                }
                return new ErrorDataResult<UserDto>();
            }
        }
    }
}
