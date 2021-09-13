using GerenciamentoDeAlunos.Core.Entities;
using GerenciamentoDeAlunos.Core.Repositories;
using GerenciamentoDeAlunos.Core.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GerenciamentoDeAlunos.Application.Commands.PostUser
{
    public class PostUserCommandHandler : IRequestHandler<PostUserCommand, int>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;

        public PostUserCommandHandler(IUserRepository userRepository, IAuthService authService)
        {
            _userRepository = userRepository;
            _authService = authService;
        }

        public async Task<int> Handle(PostUserCommand request, CancellationToken cancellationToken)
        {
            if (_userRepository == null) throw new Exception("Ocorreu um erro inesperado. Tente novamente!");

            var userExists = await _userRepository.GetUserByEmailAsync(request.Email);

            if (userExists != null) throw new Exception("Já existe um usuário com o e-mail informado!");

            var passwordHash = _authService.ComputeSha256Hash(request.Password);

            var user = new User(request.FullName, request.Email, DateTime.Now, true, passwordHash, request.Role);

            await _userRepository.AddAsync(user);

            return user.Id;
        }
    }
}
