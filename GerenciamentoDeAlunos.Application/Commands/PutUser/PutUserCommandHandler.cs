using GerenciamentoDeAlunos.Core.Entities;
using GerenciamentoDeAlunos.Core.Repositories;
using GerenciamentoDeAlunos.Core.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GerenciamentoDeAlunos.Application.Commands.PutUser
{
    public class PutUserCommandHandler : IRequestHandler<PutUserCommand, Unit>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;

        public PutUserCommandHandler(IUserRepository userRepository, IAuthService authService)
        {
            _userRepository = userRepository;
            _authService = authService;
        }

        public async Task<Unit> Handle(PutUserCommand request, CancellationToken cancellationToken)
        {
            if (_userRepository == null) throw new Exception("Ocorreu um erro inesperado. Tente novamente!");

            var userExists = await _userRepository.GetUserByEmailAsync(request.Email);

            if (userExists != null) throw new Exception("Já existe um usuário com o e-mail informado!");

            var user = await _userRepository.GetByIdAsync(request.Id);

            if (user == null) throw new Exception("Usuário não encontrado!");

            var passwordHash = _authService.ComputeSha256Hash(request.Password);

            user.Update(request.FullName, request.Email, userExists.CreatedAt,request.Active, passwordHash, request.Role);

            await _userRepository.UpdateAsync(user);

            await _userRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}