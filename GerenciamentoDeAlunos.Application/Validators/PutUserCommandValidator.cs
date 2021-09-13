﻿using FluentValidation;
using GerenciamentoDeAlunos.Application.Commands.PutUser;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace GerenciamentoDeAlunos.Application.Validators
{
    public class PutUserCommandValidator : AbstractValidator<PutUserCommand>
    {
        public PutUserCommandValidator()
        {
            RuleFor(p => p.Email)
                .EmailAddress()
                .WithMessage("E-mail não válido!");

            RuleFor(p => p.Password)
                .Must(ValidPassword)
                .WithMessage("Senha deve conter pelo menos 8 caracteres, um número, uma letra maiúscula, uma minúscula, e um caractere especial");

            RuleFor(p => p.FullName)
                .NotEmpty()
                .NotNull()
                .WithMessage("Nome é obrigatório!");

            RuleFor(p => p.Role)
                .NotEmpty()
                .NotNull()
                .WithMessage("Perfil é obrigatório!");
        }

        public bool ValidPassword(string password)
        {
            var regex = new Regex(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$");

            return regex.IsMatch(password);
        }
    }
}