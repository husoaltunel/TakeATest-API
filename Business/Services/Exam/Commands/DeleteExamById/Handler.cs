
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
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Services.Exam.Commands.DeleteExamById
{
    public class Handler : BaseConnection, IRequestHandler<DeleteExamByIdCommand, IResult>
    {
        public Handler(IDbConnection dbConnection)
        {
            Connection = dbConnection;
        }
        public async Task<IResult> Handle(DeleteExamByIdCommand request, CancellationToken cancellationToken)
        {
            using (var unitOfWork = UnitOfWorkUtil.GetUnitOfWork(Connection))
            {

                var deletedExam = await unitOfWork.DbContext.Exams.DeleteAsync(request.Id);
                if (ResultUtil<long>.IsResultSuccees(deletedExam))
                {
                    return new SuccessResult();
                }
                return new ErrorResult();

            }

        }
    }
}
