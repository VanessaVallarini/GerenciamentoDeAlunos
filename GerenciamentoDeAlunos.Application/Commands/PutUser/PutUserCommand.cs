using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GerenciamentoDeAlunos.Application.Commands.PutUser
{
    public class PutUserCommand : IRequest<Unit>
    {
        [Required]
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string FullName { get; set; }

        public string Email { get; set; }
        [Required]
        public bool Active { get; set; }

        public string Password { get; set; }

        [Required, StringLength(10)]
        public string Role { get; set; }
    }
}