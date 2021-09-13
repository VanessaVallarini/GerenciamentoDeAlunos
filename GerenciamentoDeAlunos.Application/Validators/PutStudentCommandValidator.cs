using FluentValidation;
using GerenciamentoDeAlunos.Application.Commands.PutStudent;
using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciamentoDeAlunos.Application.Validators
{
    public class PutStudentCommandValidator : AbstractValidator<PutStudentCommand>
    {
        public PutStudentCommandValidator()
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