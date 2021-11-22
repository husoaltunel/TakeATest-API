using AutoMapper;
using Business.Services.Question.Queries.GetQuestionsByExamId;
using Business.Services.Role.Queries.GetOperationClaimsByUserId;
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

namespace Business.Services.Exam.Queries.GetExamById
{
    public class Handler : BaseConnection, IRequestHandler<GetExamByIdQuery, IDataResult<ExamDto>>
    {
        private readonly IMapper _mapper;
        public Handler(IDbConnection dbConnection, IMapper mapper)
        {
            Connection = dbConnection;
            _mapper = mapper;
        }
        public async Task<IDataResult<ExamDto>> Handle(GetExamByIdQuery request, CancellationToken cancellationToken)
        {
            using (var unitOfWork = UnitOfWorkUtil.GetUnitOfWork(Connection))
            {
                var result = await unitOfWork.DbContext.Exams.GetByIdAsync(request.Id);
                if (!ResultUtil<Entities.Entities.Exam>.IsDataExist(result))
                {
                    return new ErrorDataResult<ExamDto>();
                }
                var mappedExam = _mapper.Map<ExamDto>(result);
                return new SuccessDataResult<ExamDto>(mappedExam);
            }
        }
    }
}
