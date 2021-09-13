using GerenciamentoDeAlunos.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GerenciamentoDeAlunos.Application.Queries.GetStudentById
{
    public class GetStudentByIdQueryHandler : IRequestHandler<GetStudentByIdQuery, GetStudentByIdViewModel>
    {
        private readonly IStudentRepository _studentRepository;

        public GetStudentByIdQueryHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<GetStudentByIdViewModel> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            if (_studentRepository == null) throw new Exception("Ocorreu um erro inesperado. Tente novamente!");

            var student = await _studentRepository.GetByIdAsync(request.Id);

            if (student == null) throw new Exception("Estudante não encontrado!");

            var getStudentByIdViewModel = new GetStudentByIdViewModel(
                student.FullName,
                student.Email,
                student.BirthDate,
                student.Idade,
                student.Active
                );

            return getStudentByIdViewModel;
        }
    }
}
