using Core.Utilities.Result.Abstract;
using Entities.Dtos;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Business.Services.Exam.Queries.GetExams
{
    public class GetExamsQuery : IRequest<IDataResult<IEnumerable<ExamDto>>>
    {

    }
}
