using GerenciamentoDeAlunos.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GerenciamentoDeAlunos.Application.Queries.GetAllUsers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<GetAllUsersViewModel>>
    {
        private readonly IUserRepository _userRepository;

        public GetAllUsersQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<GetAllUsersViewModel>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            if (_userRepository == null) throw new Exception("Ocorreu um erro inesperado. Tente novamente!");

            var users = await _userRepository.GetAllAsync();

            if (users.Count == 0) throw new Exception("Não há usuários cadastrados!");

            var getAllUsersViewModel = users
                .Select(u => new GetAllUsersViewModel(u.Id, u.FullName, u.Email, u.CreatedAt, u.Active, u.Password, u.Role))
                .ToList();

            return getAllUsersViewModel;
        }
    }
}