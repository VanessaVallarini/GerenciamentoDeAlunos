using GerenciamentoDeAlunos.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GerenciamentoDeAlunos.Application.Commands.DeleteCourse
{
    public class DeleteCourseCommandHandler : IRequestHandler<DeleteCourseCommand, Unit>
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IEnrollmentRepository _enrollmentRepository;

        public DeleteCourseCommandHandler(ICourseRepository courseRepository, IEnrollmentRepository enrollmentRepository)
        {
            _courseRepository = courseRepository;
            _enrollmentRepository = enrollmentRepository;
        }

        public async Task<Unit> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
        {
            if (_enrollmentRepository == null) throw new Exception("Ocorreu um erro inesperado. Tente novamente!");
            if (_courseRepository == null) throw new Exception("Ocorreu um erro inesperado. Tente novamente!");

            var course = await _courseRepository.GetByIdAsync(request.Id);
            if (course == null) throw new Exception("Curso não encontrado!");

            var numberOfEnrollmentPerStudent = _enrollmentRepository.GetCountByIdCourseAsync(request.Id);
            if (numberOfEnrollmentPerStudent.Result > 0) throw new Exception("Esse curso não pode ser deletado, pois, possui inscrições nele!");

            await _courseRepository.RemoveAsync(course);

            return Unit.Value;
        }
    }
}
