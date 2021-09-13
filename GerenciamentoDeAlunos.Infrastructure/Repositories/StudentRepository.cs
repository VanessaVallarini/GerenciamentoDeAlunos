using Dapper;
using GerenciamentoDeAlunos.Core.DTOs;
using GerenciamentoDeAlunos.Core.Entities;
using GerenciamentoDeAlunos.Core.Repositories;
using GerenciamentoDeAlunos.Infrastructure.Persistence;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoDeAlunos.Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly GerenciamentoDeAlunosDbContext _dbContext;
        private readonly string _connectionString;

        public StudentRepository(GerenciamentoDeAlunosDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _connectionString = configuration.GetConnectionString("GerenciamentoDeAlunosDb");
        }

        public async Task<List<Student>> GetAllAsync()
        {
            var students = await _dbContext.Students.ToListAsync();

            return students;
        }

        public async Task<Student> GetByIdAsync(int id)
        {
            var student = await _dbContext.Students.SingleOrDefaultAsync(s => s.Id == id);

            return student;
        }

        public async Task<List<StudentDTO>> SearchByNameAsync(string fullName)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                var script = "SELECT Id, FullName, Email, BirthDate, Idade, Active FROM Students WHERE FullName LIKE '%" + fullName + "%'";

                var students = await sqlConnection.QueryAsync<StudentDTO>(script);

                return students.ToList();
            }
        }

        public async Task<Student> GetByNameAsync(string fullName)
        {
            var student = await _dbContext.Students.SingleOrDefaultAsync(s => s.FullName == fullName);

            return student;
        }

        public async Task<Student> GetByEmailAsync(string email)
        {
            var student = await _dbContext.Students.SingleOrDefaultAsync(s => s.Email == email);

            return student;
        }

        public async Task AddAsync(Student student)
        {
            await _dbContext.Students.AddAsync(student);

            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveAsync(Student student)
        {
            _dbContext.Students.Remove(student);

            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Student student)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                var script = "UPDATE Students SET FullName = @fullName, Email = @email, BirthDate = @birthDate, Idade = @idade, Active = @active  WHERE Id = @id";

                await sqlConnection.ExecuteAsync(script, new { fullName = student.FullName, email = student.Email, birthDate = student.BirthDate, idade = student.Idade, active = student.Active, student.Id });
            }
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }  
    }
}
