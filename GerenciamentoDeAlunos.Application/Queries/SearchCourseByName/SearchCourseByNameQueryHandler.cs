using GerenciamentoDeAlunos.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GerenciamentoDeAlunos.Application.Queries.SearchCourseByName
{
    public class SearchCourseByNameQueryHandler : IRequestHandler<SearchCourseByNameQuery, List<SearchCourseByNameViewModel>>
    {
        private readonly ICourseRepository _courseRepository;

        public SearchCourseByNameQueryHandler(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<List<SearchCourseByNameViewModel>> Handle(SearchCourseByNameQuery request, CancellationToken cancellationToken)
        {
            if (_courseRepository == null) throw new Exception("Ocorreu um erro inesperado. Tente novamente!");

            var courses = await _courseRepository.SearchByNameAsync(request.Name);

            if (courses.Count() == 0) throw new Exception("Não há cursos cadastrados que contenham no nome o caracteres: " + request.Name.ToString());

            var searchCourseByNameViewModel = courses
                .Select(c => new SearchCourseByNameViewModel(c.Id, c.Name, c.Credits))
                .ToList();

            return searchCourseByNameViewModel;
        }
    }
}
