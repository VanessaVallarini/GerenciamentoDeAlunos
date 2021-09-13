using GerenciamentoDeAlunos.Core.DTOs;
using GerenciamentoDeAlunos.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoDeAlunos.Core.Repositories
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAllAsync();

        Task<Student> GetByIdAsync(int id);

        Task<List<StudentDTO>> SearchByNameAsync(string name);

        Task<Student> GetByNameAsync(string name);

        Task<Student> GetByEmailAsync(string name);

        Task AddAsync(Student student);

        Task RemoveAsync(Student student);

        Task UpdateAsync(Student student);

        Task SaveChangesAsync();
    }
}
