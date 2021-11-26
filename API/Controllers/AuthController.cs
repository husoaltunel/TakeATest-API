using Business.Services.Auth.Commands.Register;
using Business.Services.Auth.Queries.Login;
using Entities.Dtos;
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
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginQuery model)
        {
            return Ok(await _mediator.Send(model));
        } 
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterCommand model)
        {
            return Ok(await _mediator.Send(model));
        }
        [Authorize]
        [HttpGet("is-logged-in")]
        public IActionResult IsLoggedIn()
        {
            return Ok();
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("is-admin")]
        public IActionResult IsAdmin()
        {
            return Ok();
        }
    }
}
