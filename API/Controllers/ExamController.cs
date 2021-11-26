using Business.Services.Exam.Commands.DeleteExamById;
using Business.Services.Exam.Commands.InsertExamWithQuestions;
using Business.Services.Exam.Queries.GetExamById;
using Business.Services.Exam.Queries.GetExams;
using Business.Services.Exam.Queries.GetExamWithQuestionsById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ExamController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _mediator.Send(new GetExamsQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            return Ok(await _mediator.Send(new GetExamByIdQuery(){Id = id }));
        }

        [HttpGet("get-with-questions-by-id/{id}")]
        public async Task<IActionResult> GetWithQuestionsById(long id)
        {
            return Ok(await _mediator.Send(new GetExamWithQuestionsByIdQuery(){Id = id }));
        }
        [Authorize(Roles = "Admin")]
        [HttpPost("insert-with-questions")]
        public async Task<IActionResult> InsertWithQuestionsAsync(InsertExamWithQuestionsCommand model)
        {
            return Ok(await _mediator.Send(model));
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteByIdAsync(long id)
        {
            return Ok(await _mediator.Send(new DeleteExamByIdCommand(){Id = id}));
        }


    }
}
