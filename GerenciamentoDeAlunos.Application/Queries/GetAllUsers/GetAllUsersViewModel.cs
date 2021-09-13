using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciamentoDeAlunos.Application.Queries.GetAllUsers
{
    public class GetAllUsersViewModel
    {
        public GetAllUsersViewModel(int id, string fullName, string email, DateTime createdAt, bool active, string password, string role)
        {
            Id = id;
            FullName = fullName;
            Email = email;
            CreatedAt = createdAt;
            Active = active;
            Password = password;
            Role = role;
        }

        public int Id { get; private set; }
        public string FullName { get; private set; }
        public string Email { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public bool Active { get; set; }
        public string Password { get; private set; }
        public string Role { get; private set; }
    }
}
