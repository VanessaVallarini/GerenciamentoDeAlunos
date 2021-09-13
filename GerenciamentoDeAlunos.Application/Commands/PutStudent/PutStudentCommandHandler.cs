using GerenciamentoDeAlunos.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GerenciamentoDeAlunos.Application.Commands.PutStudent
{
    public class PutStudentCommandHandler : IRequestHandler<PutStudentCommand, Unit>
    {
        private readonly IStudentRepository _studentRepository;

        public PutStudentCommandHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<Unit> Handle(PutStudentCommand request, CancellationToken cancellationToken)
        {
            if (_studentRepository == null) throw new Exception("Ocorreu um erro inesperado. Tente novamente!");

            var userExistsName = await _studentRepository.GetByNameAsync(request.FullName);

            if (userExistsName != null && userExistsName.Id != request.Id) throw new Exception("Já existe um estudante com o nome informado!");

            var userExistsEmail = await _studentRepository.GetByEmailAsync(request.Email);

            if (userExistsEmail != null && userExistsName.Id != request.Id) throw new Exception("Já existe um estudante com o e-mail informado!");

            var student = await _studentRepository.GetByIdAsync(request.Id);

            if (student == null) throw new Exception("Estudante não encontrado!");

            student.Update(request.FullName, request.Email, request.BirthDate, request.Idade, student.Active);
            
            await _studentRepository.UpdateAsync(student);

            await _studentRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
