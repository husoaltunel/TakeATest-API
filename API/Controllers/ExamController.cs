using Business.Services.Exam.Queries.GetExamById;
using Business.Services.Exam.Queries.GetExams;
using Business.Services.Exam.Queries.GetExamWithQuestionsById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
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

        [HttpGet("get-with-questions-by-id")]
        public async Task<IActionResult> GetWithQuestionsById(long id)
        {
            return Ok(await _mediator.Send(new GetExamWithQuestionsByIdQuery(){Id = id }));
        }

        

    }
}
