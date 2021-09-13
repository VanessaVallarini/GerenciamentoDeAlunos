using Dapper;
using GerenciamentoDeAlunos.Core.DTOs;
using GerenciamentoDeAlunos.Core.Entities;
using GerenciamentoDeAlunos.Core.Repositories;
using GerenciamentoDeAlunos.Infrastructure.Persistence;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoDeAlunos.Infrastructure.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly GerenciamentoDeAlunosDbContext _dbContext;
        private readonly string _connectionString;

        public CourseRepository(GerenciamentoDeAlunosDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _connectionString = configuration.GetConnectionString("GerenciamentoDeAlunosDb");
        }

        public async Task AddAsync(Course course)
        {
            await _dbContext.Courses.AddAsync(course);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Course>> GetAllAsync()
        {
            var courses = await _dbContext.Courses.ToListAsync();

            return courses;
        }

        public async Task<Course> GetByIdAsync(int id)
        {
            var course = await _dbContext.Courses.SingleOrDefaultAsync(c => c.Id == id);

            return course;
        }

        public async Task<Course> GetByNameAsync(string name)
        {
            var course = await _dbContext.Courses.SingleOrDefaultAsync(c => c.Name == name);

            return course;
        }

        public async Task RemoveAsync(Course course)
        {
            _dbContext.Courses.Remove(course);

            await _dbContext.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<CourseDTO>> SearchByNameAsync(string name)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                var script = "SELECT Id, Name, Credits FROM Courses WHERE Name LIKE '%"+ name +"%'";

                var courses = await sqlConnection.QueryAsync<CourseDTO>(script);

                return courses.ToList();
            }
        }

        public async Task UpdateAsync(Course course)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                var script = "UPDATE Courses SET Name = @name, Credits = @credits WHERE Id = @id";

                await sqlConnection.ExecuteAsync(script, new { name = course.Name, credits = course.Credits, id = course.Id });
            }
        }
    }
}
