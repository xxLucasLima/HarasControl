using ArasControl.Application.DTOs;
using ArasControl.Domain.Interfaces;
using MediatR;

namespace ArasControl.Application.Queries.FeedRecord.Handler
{
    public class ListFeedRecordsByAnimalHandler : IRequestHandler<ListFeedRecordsByAnimalQuery, IEnumerable<FeedRecordDto>>
    {
        private readonly IAnimalRepository _animalRepo;

        public ListFeedRecordsByAnimalHandler(IAnimalRepository animalRepo)
        {
            _animalRepo = animalRepo;
        }

        public async Task<IEnumerable<FeedRecordDto>> Handle(ListFeedRecordsByAnimalQuery request, CancellationToken cancellationToken)
        {
            var animal = await _animalRepo.GetByIdAsync(request.AnimalId);
            if (animal == null)
                return Enumerable.Empty<FeedRecordDto>();

            return animal.FeedRecords.Select(fr => new FeedRecordDto
            {
                Id = fr.Id,
                AnimalId = fr.AnimalId,
                Amount = fr.Amount,
                Unit = fr.Unit,
                FedAt = fr.FedAt,
                Notes = fr.Notes
            });
        }
    }
}
