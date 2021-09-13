using GerenciamentoDeAlunos.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciamentoDeAlunos.Application.Queries.GetAllEnrollments
{
    public class GetAllEnrollmentsViewModel
    {
        public GetAllEnrollmentsViewModel(int id, DateTime dateEnrollment, EnrollmentGradeEnum grade)
        {
            Id = id;
            DateEnrollment = dateEnrollment;
            Grade = grade;
        }

        public int Id { get; set; }
        public DateTime DateEnrollment { get; set; }
        public EnrollmentGradeEnum Grade { get; set; }
    }
}
