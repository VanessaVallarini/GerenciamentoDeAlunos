using GerenciamentoDeAlunos.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciamentoDeAlunos.Application.Queries.GetEnrollmentById
{
    public class GetEnrollmentByIdViewModel
    {
        public GetEnrollmentByIdViewModel(DateTime dateEnrollment, EnrollmentGradeEnum grade)
        {
            DateEnrollment = dateEnrollment;
            Grade = grade;
        }

        public DateTime DateEnrollment { get; set; }
        public EnrollmentGradeEnum Grade { get; set; }
    }
}
