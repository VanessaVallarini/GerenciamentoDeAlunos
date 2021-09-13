using GerenciamentoDeAlunos.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GerenciamentoDeAlunos.Application.Commands.DeleteEnrollment
{
    public class DeleteEnrollmentCommandHandler : IRequestHandler<DeleteEnrollmentCommand, Unit>
    {
        private readonly IEnrollmentRepository _enrollmentRepository;
        private readonly IStudentRepository _studentRepository;

        public DeleteEnrollmentCommandHandler(IEnrollmentRepository enrollmentRepository, IStudentRepository studentRepository)
        {
            _enrollmentRepository = enrollmentRepository;
            _studentRepository = studentRepository;
        }

        public async Task<Unit> Handle(DeleteEnrollmentCommand request, CancellationToken cancellationToken)
        {
            if (_enrollmentRepository == null) throw new Exception("Ocorreu um erro inesperado. Tente novamente!");
            if (_studentRepository == null) throw new Exception("Ocorreu um erro inesperado. Tente novamente!");

            var enrollment = await _enrollmentRepository.GetDetailsByIdAsync(request.Id);

            if (enrollment == null) throw new Exception("Inscrição não encontrada!");

            var student = await _studentRepository.GetByIdAsync(enrollment.Student.Id);

            if (student.FullName == null) throw new Exception("Estudante não encontrado!");

            var numberOfEnrollmentPerStudent = _enrollmentRepository.GetCountByIdStudentAsync(enrollment.Student.Id);

            if (numberOfEnrollmentPerStudent.Result == 2)
            {
                student.Update(student.FullName, student.Email, student.BirthDate, student.Idade, true);
            }

            if (numberOfEnrollmentPerStudent.Result == 1)
            {
                student.Update(student.FullName, student.Email, student.BirthDate, student.Idade, false);
            }

            student.RemoveEnrollment(enrollment);

            await _enrollmentRepository.RemoveAsync(enrollment);
            await _enrollmentRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
