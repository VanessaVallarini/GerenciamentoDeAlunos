using GerenciamentoDeAlunos.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoDeAlunos.Core.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync();

        Task<User> GetByIdAsync(int id);

        Task<User> GetUserByEmailAndPasswordAsync(string email, string passwordHash);

        Task<User> GetUserByEmailAsync(string email);

        Task AddAsync(User user);

        Task RemoveAsync(User user);

        Task UpdateAsync(User user);

        Task SaveChangesAsync();
    }
}
