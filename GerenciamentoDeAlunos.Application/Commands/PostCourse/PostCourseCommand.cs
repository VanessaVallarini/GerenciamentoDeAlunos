using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GerenciamentoDeAlunos.Application.Commands.PostCourse
{
    public class PostCourseCommand : IRequest<int>
    {
        [Required, StringLength(50)]
        public string Name { get; set; }
        [Required]
        public int Credits { get; set; }
    }
}
