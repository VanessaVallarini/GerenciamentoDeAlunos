using GerenciamentoDeAlunos.Core.Entities;
using GerenciamentoDeAlunos.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GerenciamentoDeAlunos.Application.Commands.PostStudent
{
    public class PostStudentCommandHandler : IRequestHandler<PostStudentCommand, int>
    {
        private readonly IStudentRepository _studentRepository;

        public PostStudentCommandHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<int> Handle(PostStudentCommand request, CancellationToken cancellationToken)
        {
            if (_studentRepository == null) throw new Exception("Ocorreu um erro inesperado. Tente novamente!");

            var userExistsName = await _studentRepository.GetByNameAsync(request.FullName);

            if (userExistsName != null) throw new Exception("Já existe um estudante com o nome informado!");

            var userExistsEmail = await _studentRepository.GetByEmailAsync(request.Email);

            if (userExistsEmail != null) throw new Exception("Já existe um estudante com o e-mail informado!");

            var student = new Student(request.FullName, request.Email, request.BirthDate, request.Idade);
            
            await _studentRepository.AddAsync(student);

            return student.Id;
        }
    }
}
