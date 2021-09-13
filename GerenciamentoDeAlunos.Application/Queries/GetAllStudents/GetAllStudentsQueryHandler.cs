using GerenciamentoDeAlunos.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GerenciamentoDeAlunos.Application.Queries.GetAllStudents
{
    public class GetAllStudentsQueryHandler : IRequestHandler<GetAllStudentsQuery, List<GetAllStudentsViewModel>>
    {
        private readonly IStudentRepository _studentRepository;

        public GetAllStudentsQueryHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<List<GetAllStudentsViewModel>> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
        {
            if (_studentRepository == null) throw new Exception("Ocorreu um erro inesperado. Tente novamente!");

            var students = await _studentRepository.GetAllAsync();

            if (students.Count == 0) throw new Exception("Não há estudantes cadastrados!");

            var getAllStudentsViewModel = students
                .Select(s => new GetAllStudentsViewModel(s.Id, s.FullName, s.Email, s.BirthDate, s.Idade, s.Active))
                .ToList();

            return getAllStudentsViewModel;
        }
    }
}