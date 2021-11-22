using Core.Utilities.Result.Abstract;
using Entities.Dtos;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Business.Services.Question.Queries.GetQuestionsByExamId
{
    public class GetQuestionsByExamIdQuery : IRequest<IDataResult<IEnumerable<QuestionDto>>>
    {
        public long Id { get; set; }
    }
}
