using GerenciamentoDeAlunos.Application.Commands.DeleteUser;
using GerenciamentoDeAlunos.Application.Commands.LoginUser;
using GerenciamentoDeAlunos.Application.Commands.PostUser;
using GerenciamentoDeAlunos.Application.Commands.PutUser;
using GerenciamentoDeAlunos.Application.Queries.GetAllUsers;
using GerenciamentoDeAlunos.Application.Queries.GetUserById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Threading.Tasks;

namespace GerenciamentoDeAlunos.API.Controllers
{
    [Route("api/users")]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [SwaggerResponse(StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        [SwaggerResponse(StatusCodes.Status401Unauthorized)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var query = new GetAllUsersQuery();

                var result = await _mediator.Send(query);

                if (result == null) throw new Exception("Ocorreu um erro inesperado. Tente novamente!");

                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [SwaggerResponse(StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        [SwaggerResponse(StatusCodes.Status401Unauthorized)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetUserById(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            try
            {
                var query = new GetUserByIdQuery(id);

                var result = await _mediator.Send(query);

                if (result == null) throw new Exception("Ocorreu um erro inesperado. Tente novamente!");

                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [SwaggerResponse(StatusCodes.Status201Created)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        [SwaggerResponse(StatusCodes.Status401Unauthorized)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        [HttpPost("create")]
        [AllowAnonymous]
        public async Task<IActionResult> PostUser([FromBody] PostUserCommand command)
        {
            if (command.FullName == null || command.Email == null || command.Password == null || command.Role == null)
            {
                return BadRequest();
            }

            try
            {
                var id = await _mediator.Send(command);

                if (id == 0) throw new Exception("Não foi possível cadastrar esse usuário! Tente novamente.");

                return CreatedAtAction(nameof(GetUserById), new { id = id }, command);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [SwaggerResponse(StatusCodes.Status204NoContent)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        [SwaggerResponse(StatusCodes.Status401Unauthorized)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        [HttpPut("update")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PutUser([FromBody] PutUserCommand command)
        {
            if (command.Id <= 0 || command.Email == null || command.Active.ToString() == null || command.Password == null || command.Role == null)
            {
                return BadRequest();
            }

            try
            {
                var result = await _mediator.Send(command);

                if (result == null) throw new Exception("Não foi possível alterar esse usuário! Tente novamente.");

                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [SwaggerResponse(StatusCodes.Status204NoContent)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        [SwaggerResponse(StatusCodes.Status401Unauthorized)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        [HttpDelete("delete/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            try
            {
                var command = new DeleteUserCommand(id);

                var result = await _mediator.Send(command);

                if (result == null) throw new Exception("Não foi possível deletar esse usuário! Tente novamente.");

                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [SwaggerResponse(StatusCodes.Status204NoContent)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        [SwaggerResponse(StatusCodes.Status401Unauthorized)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        [HttpPut("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);

                if (result == null) throw new Exception("Falha na autenticação! Tente novamente.");

                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
