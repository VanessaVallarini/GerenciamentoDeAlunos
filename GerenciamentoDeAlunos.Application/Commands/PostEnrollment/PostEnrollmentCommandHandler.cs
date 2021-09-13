using GerenciamentoDeAlunos.Core.Entities;
using GerenciamentoDeAlunos.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GerenciamentoDeAlunos.Application.Commands.PostEnrollment
{
    public class PostEnrollmentCommandHandler : IRequestHandler<PostEnrollmentCommand, int>
    {
        private readonly IEnrollmentRepository _enrollmentRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly ICourseRepository _courseRepository;

        public PostEnrollmentCommandHandler(IEnrollmentRepository enrollmentRepository, IStudentRepository studentRepository, ICourseRepository courseRepository)
        {
            _enrollmentRepository = enrollmentRepository;
            _studentRepository = studentRepository;
            _courseRepository = courseRepository;
        }

        public async Task<int> Handle(PostEnrollmentCommand request, CancellationToken cancellationToken)
        {
            if (_enrollmentRepository == null) throw new Exception("Ocorreu um erro inesperado. Tente novamente!");
            if (_studentRepository == null) throw new Exception("Ocorreu um erro inesperado. Tente novamente!");
            if (_courseRepository == null) throw new Exception("Ocorreu um erro inesperado. Tente novamente!");

            var student = await _studentRepository.GetByIdAsync(request.IdStudent);

            if (student.FullName == null) throw new Exception("Estudante não encontrado!");

            var course = await _courseRepository.GetByIdAsync(request.IdCourse);

            if (course.Name == null) throw new Exception("Curso não encontrado!");

            var numberOfEnrollmentPerStudent = _enrollmentRepository.GetCountByIdStudentAsync(request.IdStudent);

            if (numberOfEnrollmentPerStudent.Result == 2) throw new Exception("O(a) estudante " + student.FullName.ToString() + " possui duas inscrições. Quantidade máxima permitida!");

            Enrollment enrollment = new Enrollment();
            enrollment.Student = student;
            enrollment.Course = course;
            enrollment.DateEnrollment = DateTime.Now;
            enrollment.Grade = request.Grade;

            student.SetEnrollment(enrollment);

            await _enrollmentRepository.AddAsync(enrollment);
            await _enrollmentRepository.SaveChangesAsync();

            return enrollment.Id;
        }
    }
}
