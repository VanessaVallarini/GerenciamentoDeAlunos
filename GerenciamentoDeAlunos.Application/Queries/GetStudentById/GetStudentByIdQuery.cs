using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GerenciamentoDeAlunos.Application.Queries.GetStudentById
{
    public class GetStudentByIdQuery : IRequest<GetStudentByIdViewModel>
    {
        public GetStudentByIdQuery(int id)
        {
            Id = id;
        }

        [Required]
        public int Id { get; private set; }
    }
}
