using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciamentoDeAlunos.Application.Queries.GetCourseById
{
    public class GetCourseByIdViewModel
    {
        public GetCourseByIdViewModel(string name, int credits)
        {
            Name = name;
            Credits = credits;
        }

        public string Name { get; private set; }
        public int Credits { get; private set; }
    }
}
