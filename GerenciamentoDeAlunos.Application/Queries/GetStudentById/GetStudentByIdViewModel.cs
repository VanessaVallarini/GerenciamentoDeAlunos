using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciamentoDeAlunos.Application.Queries.GetStudentById
{
    public class GetStudentByIdViewModel
    {
        public GetStudentByIdViewModel(string fullName, string email, DateTime birthDate, int idade, bool active)
        {
            FullName = fullName;
            Email = email;
            BirthDate = birthDate;
            Idade = idade;
            Active = active;
        }

        public string FullName { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }
        public int Idade { get; private set; }
        public bool Active { get; private set; }
    }
}
