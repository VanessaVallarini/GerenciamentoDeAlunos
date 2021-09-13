using FluentValidation;
using GerenciamentoDeAlunos.Application.Commands.PostEnrollment;
using GerenciamentoDeAlunos.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciamentoDeAlunos.Application.Validators
{
    public class PostEnrollmentCommandValidator : AbstractValidator<PostEnrollmentCommand>
    {
        public PostEnrollmentCommandValidator()
        {
            RuleFor(e => e.IdCourse)
                .NotEmpty()
                .NotNull()
                .WithMessage("Informe o identificador do curso!");

            RuleFor(e => e.IdStudent)
                .NotEmpty()
                .NotNull()
                .WithMessage("Informe o identificador do estudante!");

            RuleFor(e => e.Grade)
                .NotEmpty()
                .NotNull()
                .IsInEnum()
                .WithMessage("Grade inválida!");
        }
    }
}
