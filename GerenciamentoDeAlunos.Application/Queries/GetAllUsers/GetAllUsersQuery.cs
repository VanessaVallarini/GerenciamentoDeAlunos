using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciamentoDeAlunos.Application.Queries.GetAllUsers
{
    public class GetAllUsersQuery : IRequest<List<GetAllUsersViewModel>>
    {
        public GetAllUsersQuery()
        {

        }
    }
}
