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

namespace Business.Services.Exam.Queries.GetExamWithQuestionsById
{
    public class Handler : BaseConnection, IRequestHandler<GetExamWithQuestionsByIdQuery, IDataResult<ExamWithQuestionsDto>>
    {
        private readonly IMapper _mapper;
        public Handler(IDbConnection dbConnection,IMapper mapper)
        {
            Connection = dbConnection;
            _mapper =mapper;
        }
        public async Task<IDataResult<ExamWithQuestionsDto>> Handle(GetExamWithQuestionsByIdQuery request, CancellationToken cancellationToken)
        {
            using (var unitOfWork = UnitOfWorkUtil.GetUnitOfWork(Connection))
            {
                var exam = await unitOfWork.DbContext.Exams.GetByIdAsync(request.Id);           

                if (!ResultUtil<Entities.Entities.Exam>.IsDataExist(exam))
                {
                    return new ErrorDataResult<ExamWithQuestionsDto>();
                }
                var mappedExam = _mapper.Map<ExamWithQuestionsDto>(exam);
                var questionsResult = await unitOfWork.DbContext.Questions.GetQuestionsByExamId(request.Id);

                if (ResultUtil<IEnumerable<Entities.Entities.Question>>.IsDataExist(questionsResult))
                {
                    var mappedQuestions = questionsResult.Select(question => _mapper.Map<QuestionDto>(question)).ToList();
                    foreach (var question in mappedQuestions)
                    {
                        var options = await unitOfWork.DbContext.Options.GetOptionsByQuestionId(question.Id);
                        question.Options = options.Select(option => _mapper.Map<OptionDto>(option)).ToList();
                    }
                    mappedExam.Questions = mappedQuestions;
                }
                
                return new SuccessDataResult<ExamWithQuestionsDto>(mappedExam);



            }
        }
    }
}
