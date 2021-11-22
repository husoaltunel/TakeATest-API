using Core.Utilities.Result.Abstract;
using Entities.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services.Exam.Queries.GetExamWithQuestionsById
{
    public class GetExamWithQuestionsByIdQuery : IRequest<IDataResult<ExamWithQuestionsDto>>
    {
        public long Id { get;set;}
    }
}
