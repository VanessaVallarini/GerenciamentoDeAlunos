using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GerenciamentoDeAlunos.Application.Commands.DeleteCourse
{
    public class DeleteCourseCommand : IRequest<Unit>
    {
        public DeleteCourseCommand(int id)
        {
            Id = id;
        }

        [Required]
        public int Id { get; private set; }
    }
}
