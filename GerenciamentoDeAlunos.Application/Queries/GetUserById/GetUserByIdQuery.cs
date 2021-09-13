using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GerenciamentoDeAlunos.Application.Queries.GetUserById
{
    public class GetUserByIdQuery : IRequest<GetUserByIdViewModel>
    {
        public GetUserByIdQuery(int id)
        {
            Id = id;
        }

        [Required]
        public int Id { get; private set; }
    }
}
