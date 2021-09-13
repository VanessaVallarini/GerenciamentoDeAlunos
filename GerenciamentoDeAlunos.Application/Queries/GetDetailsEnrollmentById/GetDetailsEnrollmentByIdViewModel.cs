using GerenciamentoDeAlunos.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciamentoDeAlunos.Application.Queries.GetDetailsEnrollmentById
{
    public class GetDetailsEnrollmentByIdViewModel
    {
        public GetDetailsEnrollmentByIdViewModel(DateTime dateEnrollment, EnrollmentGradeEnum grade, int idCourse, string name, int idStudent, string fullName)
        {
            DateEnrollment = dateEnrollment;
            Grade = grade;

            IdCourse = idCourse;
            Name = name;

            IdStudent = idStudent;
            FullName = fullName;

        }

        
        public DateTime DateEnrollment { get; private set; }
        public EnrollmentGradeEnum Grade { get; private set; }

        public int IdCourse { get; private set; }
        public string Name { get; private set; }

        public int IdStudent { get; private set; }
        public string FullName { get; private set; }
    }
}
