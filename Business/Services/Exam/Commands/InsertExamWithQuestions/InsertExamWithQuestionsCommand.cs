using Core.Utilities.Result.Abstract;
using Entities.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services.Exam.Commands.InsertExamWithQuestions
{
    public class InsertExamWithQuestionsCommand : ExamWithQuestionsDto, IRequest<IResult>
    {

    }
}
