using Core.Utilities.Result.Abstract;
using Entities.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services.Auth.Commands.Register
{
    public class RegisterCommand :RegisterDto, IRequest<IResult>
    {

    }
}
