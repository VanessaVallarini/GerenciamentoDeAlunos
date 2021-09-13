using FluentValidation;
using GerenciamentoDeAlunos.Application.Commands.PostStudent;
using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciamentoDeAlunos.Application.Validators
{
    public class PostStudentCommandValidator : AbstractValidator<PostStudentCommand>
    {
        public PostStudentCommandValidator()
        {
            RuleFor(p => p.Email)
                .EmailAddress()
                .WithMessage("E-mail não válido!");

            RuleFor(p => p.FullName)
                .NotEmpty()
                .NotNull()
                .WithMessage("Nome é obrigatório!");
        }
    }
}