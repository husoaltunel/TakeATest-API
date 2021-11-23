
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

namespace Business.Services.Exam.Commands.InsertExamWithQuestions
{
    public class Handler : BaseConnection, IRequestHandler<InsertExamWithQuestionsCommand, IResult>
    {
        private readonly IMapper _mapper;
        public Handler(IDbConnection dbConnection, IMapper mapper)
        {
            Connection = dbConnection;
            _mapper = mapper;
        }
        public async Task<IResult> Handle(InsertExamWithQuestionsCommand request, CancellationToken cancellationToken)
        {
            using (var unitOfWork = UnitOfWorkUtil.GetUnitOfWork(Connection))
            {
                unitOfWork.OpenConnection();
                unitOfWork.BeginTransaction();
                try
                {
                    var addedExam = await unitOfWork.DbContext.Exams.InsertAsync(_mapper.Map<Entities.Entities.Exam>(request));

                    foreach (var question in request.Questions)
                    {
                        question.ExamId = addedExam;
                        var addedQuestion = await unitOfWork.DbContext.Questions.InsertAsync(_mapper.Map<Entities.Entities.Question>(question));
                        foreach (var option in question.Options)
                        {
                            option.QuestionId = addedQuestion;
                            await unitOfWork.DbContext.Options.InsertAsync(_mapper.Map<Entities.Entities.Option>(option));
                        }
                    }
                    unitOfWork.Commit();

                    return new SuccessResult();
                }
                catch (Exception)
                {

                    unitOfWork.Rollback();
                }


                return new ErrorResult();
            }

        }
    }
}
