using GerenciamentoDeAlunos.Core.Enums;
using System;

namespace GerenciamentoDeAlunos.Core.Entities
{
    public class Enrollment : BaseEntity
    {
        public Student Student { get; set; }
        public Course Course { get; set; }
        public DateTime DateEnrollment { get; set; }
        public EnrollmentGradeEnum Grade { get; set; }
    }
}
