using GerenciamentoDeAlunos.Application.Commands.DeleteCourse;
using GerenciamentoDeAlunos.Application.Commands.PostCourse;
using GerenciamentoDeAlunos.Application.Commands.PutCourse;
using GerenciamentoDeAlunos.Application.Queries.GetAllCourses;
using GerenciamentoDeAlunos.Application.Queries.GetCourseById;
using GerenciamentoDeAlunos.Application.Queries.SearchCourseByName;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Threading.Tasks;

namespace GerenciamentoDeAlunos.API.Controllers
{
    [Route("api/courses")]
    [Authorize]
    public class CourseController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CourseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [SwaggerResponse(StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        [SwaggerResponse(StatusCodes.Status401Unauthorized)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<IActionResult> GetAllCourses()
        {
            try
            {
                var query = new GetAllCoursesQuery();

                var result = await _mediator.Send(query);

                if (result == null) throw new Exception("Ocorreu um erro inesperado. Tente novamente!");

                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // api/courses/2
        [SwaggerResponse(StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        [SwaggerResponse(StatusCodes.Status401Unauthorized)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourseById(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            try
            {
                var query = new GetCourseByIdQuery(id);

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
        public async Task<IActionResult> SearchCourseByName(string name)
        {
            if (name == null)
            {
                return BadRequest();
            }

            try
            {
                var query = new SearchCourseByNameQuery(name);

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
        public async Task<IActionResult> PostCourse([FromBody] PostCourseCommand command)
        {
            if (command.Name == null || command.Credits == 0)
            {
                return BadRequest();
            }

            try
            {
                var id = await _mediator.Send(command);

                if (id == 0) throw new Exception("Não foi possível cadastrar esse curso! Tente novamente.");

                return CreatedAtAction(nameof(GetCourseById), new { id = id }, command);
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
        public async Task<IActionResult> PutCourse([FromBody] PutCourseCommand command)
        {
            if (command.Id <= 0 || command.Name == null || command.Credits == 0)
            {
                return BadRequest();
            }

            try
            {
                var result = await _mediator.Send(command);

                if (result == null) throw new Exception("Não foi possível alterar esse curso! Tente novamente.");

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
        public async Task<IActionResult> DeleteCourse(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            try
            {
                var command = new DeleteCourseCommand(id);

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
