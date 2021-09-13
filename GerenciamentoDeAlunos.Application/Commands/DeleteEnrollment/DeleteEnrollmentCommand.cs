using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GerenciamentoDeAlunos.Application.Commands.DeleteEnrollment
{
    public class DeleteEnrollmentCommand : IRequest<Unit>
    {
        public DeleteEnrollmentCommand(int id)
        {
            Id = id;
        }

        [Required]
        public int Id { get; private set; }
    }
}
