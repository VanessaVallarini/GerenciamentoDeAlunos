using GerenciamentoDeAlunos.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GerenciamentoDeAlunos.Application.Commands.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Unit>
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            if (_userRepository == null) throw new Exception("Ocorreu um erro inesperado. Tente novamente!");

            var user = await _userRepository.GetByIdAsync(request.Id);

            if (user == null) throw new Exception("Usuário não encontrado!");

            await _userRepository.RemoveAsync(user);

            return Unit.Value;
        }
    }
}
