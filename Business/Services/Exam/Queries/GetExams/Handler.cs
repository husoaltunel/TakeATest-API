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

namespace Business.Services.Exam.Queries.GetExams
{
    public class Handler :  BaseConnection, IRequestHandler<GetExamsQuery, IDataResult<IEnumerable<ExamDto>>>
    {
        private readonly IMapper _mapper;
        public Handler(IDbConnection dbConnection,IMapper mapper)
        {
            Connection = dbConnection;
            _mapper = mapper;
        }
        public async Task<IDataResult<IEnumerable<ExamDto>>> Handle(GetExamsQuery request, CancellationToken cancellationToken)
        {
            using (var unitOfWork = UnitOfWorkUtil.GetUnitOfWork(Connection))
            {
                var result = await unitOfWork.DbContext.Exams.GetAllAsync();
                if (!ResultUtil<IEnumerable<Entities.Entities.Exam>>.IsDataExist(result))
                {
                    return new ErrorDataResult<IEnumerable<ExamDto>>();
                }
                var exams = result.ToList().Select(exam => _mapper.Map<ExamDto>(exam)); 
                return new SuccessDataResult<IEnumerable<ExamDto>>(exams);
            }
        }
    }
}
