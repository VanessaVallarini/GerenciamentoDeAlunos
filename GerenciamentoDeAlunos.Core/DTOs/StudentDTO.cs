using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciamentoDeAlunos.Core.DTOs
{
    public class StudentDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public int Idade { get; set; }
        public bool Active { get; set; }
    }
}
