using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciamentoDeAlunos.Application.Queries.GetDetailsEnrollmentById
{
    public class GetDetailsEnrollmentByIdQuery : IRequest<GetDetailsEnrollmentByIdViewModel>
    {
        public GetDetailsEnrollmentByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
