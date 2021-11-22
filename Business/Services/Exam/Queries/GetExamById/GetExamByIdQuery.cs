using Core.Utilities.Result.Abstract;
using Entities.Dtos;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Business.Services.Exam.Queries.GetExamById
{
    public class GetExamByIdQuery : IRequest<IDataResult<ExamDto>>
    {
        public long Id { get; set; }
    }
}
