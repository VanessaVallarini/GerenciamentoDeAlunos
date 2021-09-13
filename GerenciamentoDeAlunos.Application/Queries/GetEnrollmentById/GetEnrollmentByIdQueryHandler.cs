using GerenciamentoDeAlunos.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GerenciamentoDeAlunos.Application.Queries.GetEnrollmentById
{
    public class GetEnrollmentByIdQueryHandler : IRequestHandler<GetEnrollmentByIdQuery, GetEnrollmentByIdViewModel>
    {
        private readonly IEnrollmentRepository _enrollmentRepository;

        public GetEnrollmentByIdQueryHandler(IEnrollmentRepository enrollmentRepository)
        {
            _enrollmentRepository = enrollmentRepository;
        }

        public async Task<GetEnrollmentByIdViewModel> Handle(GetEnrollmentByIdQuery request, CancellationToken cancellationToken)
        {
            if (_enrollmentRepository == null) throw new Exception("Ocorreu um erro inesperado. Tente novamente!");

            var enrollment = await _enrollmentRepository.GetByIdAsync(request.Id);

            if (enrollment == null) throw new Exception("Inscrição não encontrada!");

            var getEnrollmentByIdViewModel = new GetEnrollmentByIdViewModel(
                enrollment.DateEnrollment,
                enrollment.Grade
                );

            return getEnrollmentByIdViewModel;
        }
    }
}
