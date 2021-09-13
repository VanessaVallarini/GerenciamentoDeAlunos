using GerenciamentoDeAlunos.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GerenciamentoDeAlunos.Application.Queries.SearchStudentByName
{
    public class SearchStudentByNameQueryHandler : IRequestHandler<SearchStudentByNameQuery, List<SearchStudentByNameViewModel>>
    {
        private readonly IStudentRepository _studentRepository;

        public SearchStudentByNameQueryHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<List<SearchStudentByNameViewModel>> Handle(SearchStudentByNameQuery request, CancellationToken cancellationToken)
        {
            if (_studentRepository == null) throw new Exception("Ocorreu um erro inesperado. Tente novamente!");

            var students = await _studentRepository.SearchByNameAsync(request.Name);

            if (students.Count() == 0) throw new Exception("Não há estudantes cadastrados que contenham no nome o caracteres: " + request.Name.ToString());

            var searchStudentByNameViewModel = students
                .Select(s => new SearchStudentByNameViewModel(s.Id, s.FullName, s.Email, s.BirthDate, s.Idade, s.Active))
                .ToList();

            return searchStudentByNameViewModel;
        }
    }
}