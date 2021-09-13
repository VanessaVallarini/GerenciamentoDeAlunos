using GerenciamentoDeAlunos.Application.Commands.DeleteStudent;
using GerenciamentoDeAlunos.Application.Commands.PostStudent;
using GerenciamentoDeAlunos.Application.Commands.PutStudent;
using GerenciamentoDeAlunos.Application.Queries.GetAllStudents;
using GerenciamentoDeAlunos.Application.Queries.GetStudentById;
using GerenciamentoDeAlunos.Application.Queries.SearchStudentByName;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoDeAlunos.API.Controllers
{
    [Route("api/students")]
    [Authorize]
    public class StudentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StudentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [SwaggerResponse(StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        [SwaggerResponse(StatusCodes.Status401Unauthorized)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            try
            {
                var query = new GetAllStudentsQuery();

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
        public async Task<IActionResult> GetStudentById(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            try
            {
                var query = new GetStudentByIdQuery(id);

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
        [HttpGet("search/{name}")]
        public async Task<IActionResult> SearchStudentByName(string name)
        {
            if (name == null)
            {
                return BadRequest();
            }

            try
            {
                var query = new SearchStudentByNameQuery(name);

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
        public async Task<IActionResult> PostStudent([FromBody] PostStudentCommand command)
        {
            if (command.FullName == null || command.Email == null || command.BirthDate == null || command.Idade == 0)
            {
                return BadRequest();
            }

            try
            {
                var id = await _mediator.Send(command);

                if (id == 0) throw new Exception("Não foi possível cadastrar esse estudente! Tente novamente.");

                return CreatedAtAction(nameof(GetStudentById), new { id = id }, command);
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
        public async Task<IActionResult> PutStudent([FromBody] PutStudentCommand command)
        {
            if (command.FullName == null || command.Email == null || command.BirthDate == null || command.Idade == 0)
            {
                return BadRequest();
            }

            try
            {
                var result = await _mediator.Send(command);

                if (result == null) throw new Exception("Não foi possível alterar esse estudante! Tente novamente.");

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
        public async Task<IActionResult> DeleteStudent(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            try
            {
                var command = new DeleteStudentCommand(id);

                var result = await _mediator.Send(command);

                if (result == null) throw new Exception("Não foi possível deletar esse curso! Tente novamente.");

                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
