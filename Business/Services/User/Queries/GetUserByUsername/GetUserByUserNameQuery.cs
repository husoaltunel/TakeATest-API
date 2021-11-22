using Core.Utilities.Result.Abstract;
using Entities.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services.User.Queries.GetUserByUsername
{
    public class GetUserByUserNameQuery :  IRequest<IDataResult<UserDto>>
    {
        public string Username { get;set;}
    }
}
