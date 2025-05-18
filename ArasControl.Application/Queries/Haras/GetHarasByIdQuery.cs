using ArasControl.Application.DTOs;
using MediatR;

namespace ArasControl.Application.Queries.Haras
{
    public class GetHarasByIdQuery : IRequest<HarasDto>
    {
        public Guid Id { get; set; }

        public GetHarasByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
