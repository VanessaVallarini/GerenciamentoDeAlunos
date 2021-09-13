using System;
using System.Collections.Generic;

namespace GerenciamentoDeAlunos.Core.Entities
{
    public class Student : BaseEntity
    {
        public Student(string fullName, string email, DateTime birthDate, int idade)
        {
            FullName = fullName;
            Email = email;
            BirthDate = birthDate;
            Idade = idade;
            Active = false;
            Enrollments = new List<Enrollment>();
        }

        public string FullName { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }
        public int Idade { get; private set; }
        public bool Active { get; private set; }
        public List<Enrollment> Enrollments { get; private set; }

        public void Update(string fullName, string email, DateTime birthDate, int idade, bool active)
        {
            FullName = fullName;
            Email = email;
            BirthDate = birthDate;
            Idade = idade;
            Active = active;
        }

        public void SetEnrollment(Enrollment enrollment)
        {
            Enrollments.Add(enrollment);
            Active = true;
        }

        public void RemoveEnrollment(Enrollment enrollment)
        {
            Enrollments.Remove(enrollment);
        }
    }
}
