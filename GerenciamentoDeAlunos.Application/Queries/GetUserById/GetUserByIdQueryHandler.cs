using GerenciamentoDeAlunos.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GerenciamentoDeAlunos.Application.Queries.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, GetUserByIdViewModel>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByIdQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<GetUserByIdViewModel> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            if (_userRepository == null) throw new Exception("Ocorreu um erro inesperado. Tente novamente!");

            var user = await _userRepository.GetByIdAsync(request.Id);

            if (user == null) throw new Exception("Usuário não encontrado!");

            var getCourseByIdViewModel = new GetUserByIdViewModel(user.FullName, user.Email, user.CreatedAt, user.Active, user.Password, user.Role);

            return getCourseByIdViewModel;
        }
    }
}
