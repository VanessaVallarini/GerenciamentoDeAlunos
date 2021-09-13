using GerenciamentoDeAlunos.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoDeAlunos.Core.Repositories
{
    public interface IEnrollmentRepository
    {
        Task<List<Enrollment>> GetAllAsync();

        Task<Enrollment> GetByIdAsync(int id);

        Task<Enrollment> GetDetailsByIdAsync(int id);

        Task<int> GetCountByIdStudentAsync(int id);

        Task<int> GetCountByIdCourseAsync(int id);

        Task AddAsync(Enrollment enrollment);

        Task RemoveAsync(Enrollment enrollment);

        Task SaveChangesAsync();
    }
}
