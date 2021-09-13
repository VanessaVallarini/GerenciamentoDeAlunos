using MediatR;
using System.Collections.Generic;

namespace GerenciamentoDeAlunos.Application.Queries.GetAllCourses
{
    public class GetAllCoursesQuery : IRequest<List<GetAllCoursesViewModel>>
    {
        public GetAllCoursesQuery()
        {

        }
    }
}
