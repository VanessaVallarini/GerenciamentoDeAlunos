using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GerenciamentoDeAlunos.Application.Queries.GetEnrollmentById
{
    public class GetEnrollmentByIdQuery : IRequest<GetEnrollmentByIdViewModel>
    {
        public GetEnrollmentByIdQuery(int id)
        {
            Id = id;
        }

        [Required]
        public int Id { get; private set; }
    }
}