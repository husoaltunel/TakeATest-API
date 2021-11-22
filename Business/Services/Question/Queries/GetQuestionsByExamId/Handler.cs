using AutoMapper;
using Business.Services.Option.Queries.GetOptionsByQuestionId;
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

namespace Business.Services.Question.Queries.GetQuestionsByExamId
{
    public class Handler : BaseConnection, IRequestHandler<GetQuestionsByExamIdQuery, IDataResult<IEnumerable<QuestionDto>>>
    {
        private readonly IMapper _mapper;
        public Handler(IDbConnection dbConnection, IMapper mapper)
        {
            Connection = dbConnection;
            _mapper = mapper;
        }
        public async Task<IDataResult<IEnumerable<QuestionDto>>> Handle(GetQuestionsByExamIdQuery request, CancellationToken cancellationToken)
        {
            using (var unitOfWork = UnitOfWorkUtil.GetUnitOfWork(Connection))
            {
                var result = await unitOfWork.DbContext.Questions.GetQuestionsByExamId(request.Id);
                if (!ResultUtil<IEnumerable<Entities.Entities.Question>>.IsDataExist(result))
                {
                    return new ErrorDataResult<IEnumerable<QuestionDto>>();
                }
                var questions = result.Select(question => _mapper.Map<QuestionDto>(question));
                return new SuccessDataResult<IEnumerable<QuestionDto>>(questions);
            }
        }
    }
}
