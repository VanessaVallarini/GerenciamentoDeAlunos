using GerenciamentoDeAlunos.Core.DTOs;
using GerenciamentoDeAlunos.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GerenciamentoDeAlunos.Core.Repositories
{
    public interface ICourseRepository
    {
        Task<List<Course>> GetAllAsync();

        Task<Course> GetByIdAsync(int id);

        Task<List<CourseDTO>> SearchByNameAsync(string name);

        Task<Course> GetByNameAsync(string name);

        Task AddAsync(Course course);

        Task RemoveAsync(Course course);

        Task UpdateAsync(Course course);

        Task SaveChangesAsync();
    }
}
