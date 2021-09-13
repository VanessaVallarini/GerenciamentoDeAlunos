using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GerenciamentoDeAlunos.Application.Queries.SearchStudentByName
{
    public class SearchStudentByNameQuery : IRequest<List<SearchStudentByNameViewModel>>
    {
        public SearchStudentByNameQuery(string name)
        {
            Name = name;
        }

        [Required, StringLength(50)]
        public string Name { get; private set; }
    }
}
