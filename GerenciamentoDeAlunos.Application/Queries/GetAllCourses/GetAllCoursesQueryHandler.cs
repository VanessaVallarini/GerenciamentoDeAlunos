using GerenciamentoDeAlunos.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GerenciamentoDeAlunos.Application.Queries.GetAllCourses
{
    public class GetAllCoursesQueryHandler : IRequestHandler<GetAllCoursesQuery, List<GetAllCoursesViewModel>>
    {
        private readonly ICourseRepository _courseRepository;

        public GetAllCoursesQueryHandler(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<List<GetAllCoursesViewModel>> Handle(GetAllCoursesQuery request, CancellationToken cancellationToken)
        {
            if (_courseRepository == null) throw new Exception("Ocorreu um erro inesperado.Tente novamente!");

            var courses = await _courseRepository.GetAllAsync();

            if (courses.Count == 0) throw new Exception("Não há cursos cadastrados!");

            var getAllCoursesViewModel = courses
                .Select(c => new GetAllCoursesViewModel(c.Id, c.Name, c.Credits))
                .ToList();

            return getAllCoursesViewModel;
        }
    }
}
