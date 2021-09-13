using GerenciamentoDeAlunos.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoDeAlunos.Infrastructure.Persistence
{
    public class GerenciamentoDeAlunosDbContext : DbContext
    {
        public GerenciamentoDeAlunosDbContext(DbContextOptions<GerenciamentoDeAlunosDbContext> options)
            : base(options)//passando as infromações de conexões para o DbContext
        {

        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
