using ArasControl.Application.DTOs;
using MediatR;

namespace ArasControl.Application.Queries.FeedInventory
{
    public class GetFeedInventoryByAnimalIdQuery : IRequest<FeedInventoryDto>
    {
        public Guid AnimalId { get; set; }
        public GetFeedInventoryByAnimalIdQuery(Guid animalId)
        {
            AnimalId = animalId;
        }
    }
}
