using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciamentoDeAlunos.Application.Queries.GetAllStudents
{
    public class GetAllStudentsQuery : IRequest<List<GetAllStudentsViewModel>>
    {
        public GetAllStudentsQuery()
        {

        }
    }
}
