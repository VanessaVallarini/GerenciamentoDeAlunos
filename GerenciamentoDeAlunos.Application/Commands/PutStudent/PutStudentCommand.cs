using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GerenciamentoDeAlunos.Application.Commands.PutStudent
{
    public class PutStudentCommand : IRequest<Unit>
    {
        [Required]
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string FullName { get; set; }

        public string Email { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public int Idade { get; set; }
    }
}
