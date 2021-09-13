using GerenciamentoDeAlunos.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GerenciamentoDeAlunos.Application.Commands.DeleteStudent
{
    public class DeleteStudentCommandHandler : IRequestHandler<DeleteStudentCommand, Unit>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IEnrollmentRepository _enrollmentRepository;

        public DeleteStudentCommandHandler(IStudentRepository studentRepository, IEnrollmentRepository enrollmentRepository)
        {
            _studentRepository = studentRepository;
            _enrollmentRepository = enrollmentRepository;
        }

        public async Task<Unit> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            if (_enrollmentRepository == null) throw new Exception("Ocorreu um erro inesperado. Tente novamente!");
            if (_studentRepository == null) throw new Exception("Ocorreu um erro inesperado. Tente novamente!");

            var student = await _studentRepository.GetByIdAsync(request.Id);
            if (student == null) throw new Exception("Estudante não encontrado!");

            var numberOfEnrollmentPerStudent = _enrollmentRepository.GetCountByIdStudentAsync(request.Id);
            if (numberOfEnrollmentPerStudent.Result > 0) throw new Exception("Esse estudante não pode ser deletado, pois, ele possui inscrições!");

            await _studentRepository.RemoveAsync(student);

            return Unit.Value;
        }
    }
}
