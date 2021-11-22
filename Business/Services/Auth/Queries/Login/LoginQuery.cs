using Core.Utilities.Result.Abstract;
using Entities.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services.Auth.Queries.Login
{
    public class LoginQuery : LoginDto,IRequest<IDataResult<LoginInfoDto>>
    {

    }
}
