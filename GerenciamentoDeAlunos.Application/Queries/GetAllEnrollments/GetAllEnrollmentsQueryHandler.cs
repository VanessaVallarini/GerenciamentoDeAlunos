using GerenciamentoDeAlunos.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GerenciamentoDeAlunos.Application.Queries.GetAllEnrollments
{
    public class GetAllEnrollmentsQueryHandler : IRequestHandler<GetAllEnrollmentsQuery, List<GetAllEnrollmentsViewModel>>
    {
        private readonly IEnrollmentRepository _enrollmentRepository;

        public GetAllEnrollmentsQueryHandler(IEnrollmentRepository enrollmentRepository)
        {
            _enrollmentRepository = enrollmentRepository;
        }

        public async Task<List<GetAllEnrollmentsViewModel>> Handle(GetAllEnrollmentsQuery request, CancellationToken cancellationToken)
        {
            if (_enrollmentRepository == null) throw new Exception("Ocorreu um erro inesperado. Tente novamente!");

            var enrollments = await _enrollmentRepository.GetAllAsync();

            if (enrollments.Count == 0) throw new Exception("Não há inscrições cadastradas!");

            var getAllEnrollmentsViewModel = enrollments
                .Select(e => new GetAllEnrollmentsViewModel(e.Id, e.DateEnrollment, e.Grade))
                .ToList();
            
            return getAllEnrollmentsViewModel;
        }
    }
}
