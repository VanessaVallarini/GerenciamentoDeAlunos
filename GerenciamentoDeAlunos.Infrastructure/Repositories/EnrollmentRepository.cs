using Dapper;
using GerenciamentoDeAlunos.Core.Entities;
using GerenciamentoDeAlunos.Core.Repositories;
using GerenciamentoDeAlunos.Infrastructure.Persistence;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoDeAlunos.Infrastructure.Repositories
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        private readonly GerenciamentoDeAlunosDbContext _dbContext;
        private readonly string _connectionString;

        public EnrollmentRepository(GerenciamentoDeAlunosDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _connectionString = configuration.GetConnectionString("GerenciamentoDeAlunosDb");
        }

        public async Task<List<Enrollment>> GetAllAsync()
        {
            var enrollments = await _dbContext.Enrollments.ToListAsync();

            return enrollments;
        }

        public async Task<Enrollment> GetByIdAsync(int id)
        {
            var enrollment = await _dbContext.Enrollments.SingleOrDefaultAsync(e => e.Id == id);

            return enrollment;
        }

        public async Task<Enrollment> GetDetailsByIdAsync(int id)
        {
            var enrollment = await _dbContext.Enrollments
                .Include(c => c.Course)
                .Include(s => s.Student)
                .SingleOrDefaultAsync(e => e.Id == id);

            return enrollment;
        }

        public async Task<int> GetCountByIdStudentAsync(int id)
        {
            var enrollment = await _dbContext.Enrollments
                .Include(c => c.Course)
                .Include(s => s.Student)
                .CountAsync(e => e.Student.Id == id);

            return enrollment;
        }

        public async Task<int> GetCountByIdCourseAsync(int id)
        {
            var enrollment = await _dbContext.Enrollments
                .Include(c => c.Course)
                .Include(s => s.Student)
                .CountAsync(e => e.Course.Id == id);

            return enrollment;
        }

        public async Task AddAsync(Enrollment enrollment)
        {
            await _dbContext.Enrollments.AddAsync(enrollment);

            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveAsync(Enrollment enrollment)
        {
            _dbContext.Enrollments.Remove(enrollment);

            await _dbContext.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }   
    }
}
