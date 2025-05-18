using ArasControl.Application.DTOs;
using MediatR;

namespace ArasControl.Application.Queries.Animal
{
    public class ListAnimalsByHarasQuery : IRequest<IEnumerable<AnimalDto>>
    {
        public Guid HarasId { get; set; }
        public ListAnimalsByHarasQuery(Guid harasId)
        {
            HarasId = harasId;
        }
    }
}
