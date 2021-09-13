using GerenciamentoDeAlunos.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GerenciamentoDeAlunos.Application.Commands.PutCourse
{
    public class PutCourseCommandHandler : IRequestHandler<PutCourseCommand, Unit>
    {
        private readonly ICourseRepository _courseRepository;

        public PutCourseCommandHandler(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<Unit> Handle(PutCourseCommand request, CancellationToken cancellationToken)
        {
            if (_courseRepository == null) throw new Exception("Ocorreu um erro inesperado. Tente novamente!");

            var courseExists = await _courseRepository.GetByNameAsync(request.Name);

            if (courseExists != null) throw new Exception("Já existe um curso com o nome informado!");

            var course = await _courseRepository.GetByIdAsync(request.Id);

            if (course == null) throw new Exception("Curso não encontrado!");

            course.Update(request.Name, request.Credits);

            await _courseRepository.UpdateAsync(course);

            await _courseRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
