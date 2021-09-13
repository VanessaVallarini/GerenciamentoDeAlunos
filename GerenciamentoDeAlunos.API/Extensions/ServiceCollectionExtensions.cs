using GerenciamentoDeAlunos.Core.Repositories;
using GerenciamentoDeAlunos.Core.Services;
using GerenciamentoDeAlunos.Infrastructure.Auth;
using GerenciamentoDeAlunos.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoDeAlunos.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IEnrollmentRepository, EnrollmentRepository>();
            services.AddScoped<IAuthService, AuthService>();

            return services;
        }
    }
}
