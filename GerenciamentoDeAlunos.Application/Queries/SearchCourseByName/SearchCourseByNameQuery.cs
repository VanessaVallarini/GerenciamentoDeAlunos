using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GerenciamentoDeAlunos.Application.Queries.SearchCourseByName
{
    public class SearchCourseByNameQuery : IRequest<List<SearchCourseByNameViewModel>>
    {
        public SearchCourseByNameQuery(string name)
        {
            Name = name;
        }

        [Required, StringLength(50)]
        public string Name { get; private set; }
    }
}