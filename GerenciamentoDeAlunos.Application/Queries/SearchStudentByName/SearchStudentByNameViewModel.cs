using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciamentoDeAlunos.Application.Queries.SearchStudentByName
{
    public class SearchStudentByNameViewModel
    {
        public SearchStudentByNameViewModel(int id, string fullName, string email, DateTime birthDate, int idade, bool active)
        {
            Id = id;
            FullName = fullName;
            Email = email;
            BirthDate = birthDate;
            Idade = idade;
            Active = active;
        }

        public int Id { get; private set; }
        public string FullName { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }
        public int Idade { get; private set; }
        public bool Active { get; private set; }
    }
}
