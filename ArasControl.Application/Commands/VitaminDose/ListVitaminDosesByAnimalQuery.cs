using ArasControl.Application.DTOs;
using MediatR;

namespace ArasControl.Application.Commands.VitaminDose
{
    public class ListVitaminDosesByAnimalQuery : IRequest<IEnumerable<VitaminDoseDto>>
    {
        public Guid AnimalId { get; set; }
        public ListVitaminDosesByAnimalQuery(Guid animalId)
        {
            AnimalId = animalId;
        }
    }
}
