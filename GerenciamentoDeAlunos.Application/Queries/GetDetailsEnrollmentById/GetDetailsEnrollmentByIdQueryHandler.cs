using GerenciamentoDeAlunos.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GerenciamentoDeAlunos.Application.Queries.GetDetailsEnrollmentById
{
    public class GetDetailsEnrollmentByIdQueryHandler : IRequestHandler<GetDetailsEnrollmentByIdQuery, GetDetailsEnrollmentByIdViewModel>
    {
        private readonly IEnrollmentRepository _enrollmentRepository;

        public GetDetailsEnrollmentByIdQueryHandler(IEnrollmentRepository enrollmentRepository)
        {
            _enrollmentRepository = enrollmentRepository;
        }

        public async Task<GetDetailsEnrollmentByIdViewModel> Handle(GetDetailsEnrollmentByIdQuery request, CancellationToken cancellationToken)
        {
            if (_enrollmentRepository == null) throw new Exception("Ocorreu um erro inesperado. Tente novamente!");

            var enrollment = await _enrollmentRepository.GetDetailsByIdAsync(request.Id);

            if (enrollment == null) throw new Exception("Inscrição não encontrada!");

            var getDetailsEnrollmentByIdViewModel = new GetDetailsEnrollmentByIdViewModel(
                enrollment.DateEnrollment,
                enrollment.Grade,
                enrollment.Course.Id,
                enrollment.Course.Name,
                enrollment.Student.Id,
                enrollment.Student.FullName
                );

            return getDetailsEnrollmentByIdViewModel;
        }
    }
}