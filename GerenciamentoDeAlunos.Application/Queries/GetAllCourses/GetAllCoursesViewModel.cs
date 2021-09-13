﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciamentoDeAlunos.Application.Queries.GetAllCourses
{
    public class GetAllCoursesViewModel
    {
        public GetAllCoursesViewModel(int id, string name, int credits)
        {
            Id = id;
            Name = name;
            Credits = credits;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public int Credits { get; private set; }
    }
}
