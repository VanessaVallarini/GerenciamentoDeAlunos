using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GerenciamentoDeAlunos.Application.Commands.DeleteStudent
{
    public class DeleteStudentCommand : IRequest<Unit>
    {
        public DeleteStudentCommand(int id)
        {
            Id = id;
        }

        [Required]
        public int Id { get; private set; }
    }
}