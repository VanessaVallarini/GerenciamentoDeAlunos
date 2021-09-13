using GerenciamentoDeAlunos.Core.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GerenciamentoDeAlunos.Application.Commands.PostEnrollment
{
    public class PostEnrollmentCommand : IRequest<int>
    {
        [Required]
        public EnrollmentGradeEnum Grade { get; set; }
        [Required]
        public int IdStudent { get; set; }
        [Required]
        public int IdCourse { get; set; }
    }
}
