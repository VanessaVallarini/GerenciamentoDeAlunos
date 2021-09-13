using GerenciamentoDeAlunos.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GerenciamentoDeAlunos.Application.Queries.GetCourseById
{
    public class GetCourseByIdQueryHandler : IRequestHandler<GetCourseByIdQuery, GetCourseByIdViewModel>
    {
        private readonly ICourseRepository _courseRepository;

        public GetCourseByIdQueryHandler(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<GetCourseByIdViewModel> Handle(GetCourseByIdQuery request, CancellationToken cancellationToken)
        {
            if (_courseRepository == null) throw new Exception("Ocorreu um erro inesperado. Tente novamente!");

            var course = await _courseRepository.GetByIdAsync(request.Id);

            if (course == null) throw new Exception("Curso não encontrado!");

            var getCourseByIdViewModel = new GetCourseByIdViewModel(course.Name, course.Credits);

            return getCourseByIdViewModel;
        }
    }
}
