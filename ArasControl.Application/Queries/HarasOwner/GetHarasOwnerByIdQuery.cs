using ArasControl.Application.DTOs;
using MediatR;

namespace ArasControl.Application.Queries.HarasOwner
{
    public class GetHarasOwnerByIdQuery : IRequest<HarasOwnerDto>
    {
        public Guid Id { get; set; }
        public GetHarasOwnerByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
