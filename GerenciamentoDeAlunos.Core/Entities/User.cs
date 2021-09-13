using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciamentoDeAlunos.Core.Entities
{
    public class User : BaseEntity
    {
        public User(string fullName, string email, DateTime createdAt, bool active, string password, string role)
        {
            FullName = fullName;
            Email = email;
            CreatedAt = createdAt;
            Active = active;
            Password = password;
            Role = role;
        }

        public string FullName { get; private set; }
        public string Email { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public bool Active { get; private set; }
        public string Password { get; private set; }
        public string Role { get; private set; }

        public void Update(string fullName, string email, DateTime createdAt, bool active, string password, string role)
        {
            FullName = fullName;
            Email = email;
            CreatedAt = createdAt;
            Active = active;
            Password = password;
            Role = role;
        }
    }
}
