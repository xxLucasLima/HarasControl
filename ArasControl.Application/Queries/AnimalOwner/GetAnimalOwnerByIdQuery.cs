using ArasControl.Application.DTOs;
using MediatR;

namespace ArasControl.Application.Queries.AnimalOwner
{
    public class GetAnimalOwnerByIdQuery : IRequest<AnimalOwnerDto>
    {
        public Guid Id { get; set; }
        public GetAnimalOwnerByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
