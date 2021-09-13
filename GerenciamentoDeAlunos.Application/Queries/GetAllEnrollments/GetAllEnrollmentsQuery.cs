using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciamentoDeAlunos.Application.Queries.GetAllEnrollments
{
    public class GetAllEnrollmentsQuery : IRequest<List<GetAllEnrollmentsViewModel>>
    {
        public GetAllEnrollmentsQuery()
        {

        }
    }
}
