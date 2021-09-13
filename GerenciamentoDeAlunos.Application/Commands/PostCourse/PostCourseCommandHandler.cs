using GerenciamentoDeAlunos.Core.Entities;
using GerenciamentoDeAlunos.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GerenciamentoDeAlunos.Application.Commands.PostCourse
{
    public class PostCourseCommandHandler : IRequestHandler<PostCourseCommand, int>
    {
        private readonly ICourseRepository _courseRepository;

        public PostCourseCommandHandler(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<int> Handle(PostCourseCommand request, CancellationToken cancellationToken)
        {
            if (_courseRepository == null) throw new Exception("Ocorreu um erro inesperado. Tente novamente!");

            var userExists = await _courseRepository.GetByNameAsync(request.Name);

            if (userExists != null) throw new Exception("Já existe um curso com o nome informado!");

            var course = new Course(request.Name, request.Credits);

            await _courseRepository.AddAsync(course);

            return course.Id;
        }
    }
}
