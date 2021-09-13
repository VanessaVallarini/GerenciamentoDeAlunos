using GerenciamentoDeAlunos.Application.Commands.DeleteEnrollment;
using GerenciamentoDeAlunos.Application.Commands.PostEnrollment;
using GerenciamentoDeAlunos.Application.Queries.GetAllEnrollments;
using GerenciamentoDeAlunos.Application.Queries.GetDetailsEnrollmentById;
using GerenciamentoDeAlunos.Application.Queries.GetEnrollmentById;
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
    [Route("api/enrollments")]
    [Authorize]
    public class EnrollmentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EnrollmentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [SwaggerResponse(StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        [SwaggerResponse(StatusCodes.Status401Unauthorized)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<IActionResult> GetAllEnrollments()
        {
            try
            {
                var query = new GetAllEnrollmentsQuery();

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
        public async Task<IActionResult> GetEnrollmentById(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            try
            {
                var query = new GetEnrollmentByIdQuery(id);

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
        [HttpGet("details/{id}")]
        public async Task<IActionResult> GetDetailsEnrollmentById(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            try
            {
                var query = new GetDetailsEnrollmentByIdQuery(id);

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
        public async Task<IActionResult> PostEnrollment([FromBody] PostEnrollmentCommand command)
        {
            if (command.IdStudent <= 0 || command.IdCourse <= 0)
            {
                return BadRequest();
            }

            try
            {
                var id = await _mediator.Send(command);

                if (id == 0) throw new Exception("Não foi possível cadastrar esse estudente! Tente novamente.");

                return CreatedAtAction(nameof(GetEnrollmentById), new { id = id }, command);
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
        public async Task<IActionResult> DeleteEnrollment(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            try
            {
                var command = new DeleteEnrollmentCommand(id);

                var result = await _mediator.Send(command);

                if (result == null) throw new Exception("Não foi possível deletar essa inscrição! Tente novamente.");

                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}