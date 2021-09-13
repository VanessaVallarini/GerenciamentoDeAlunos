using MediatR;
using System.ComponentModel.DataAnnotations;

namespace GerenciamentoDeAlunos.Application.Queries.GetCourseById
{
    public class GetCourseByIdQuery : IRequest<GetCourseByIdViewModel>
    {
        public GetCourseByIdQuery(int id)
        {
            Id = id;
        }

        [Required]
        public int Id { get; private set; }
    }
}
