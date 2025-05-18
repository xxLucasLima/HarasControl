using ArasControl.Application.DTOs;
using MediatR;

namespace ArasControl.Application.Queries.FeedRecord
{
    public class ListFeedRecordsByAnimalQuery : IRequest<IEnumerable<FeedRecordDto>>
    {
        public Guid AnimalId { get; set; }
        public ListFeedRecordsByAnimalQuery(Guid animalId)
        {
            AnimalId = animalId;
        }
    }
}
