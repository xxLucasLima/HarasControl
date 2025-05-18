using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArasControl.Domain.Interfaces;
using MediatR;

namespace ArasControl.Application.Commands.FeedRecord.Handler
{
    public class AddFeedRecordHandler : IRequestHandler<AddFeedRecordCommand, Guid>
    {
        private readonly IAnimalRepository _animalRepo;

        public AddFeedRecordHandler(IAnimalRepository animalRepo)
        {
            _animalRepo = animalRepo;
        }
        public async Task<Guid> Handle(AddFeedRecordCommand request, CancellationToken cancellationToken)
        {
            var animal = await _animalRepo.GetByIdAsync(request.AnimalId);
            if (animal == null)
                throw new Exception("Animal não encontrado.");

            var feedRecord = new Domain.Entities.FeedRecord(
                Guid.NewGuid(),
                request.AnimalId,
                request.Amount,
                request.Unit,
                request.FedAt,
                request.Notes
            );

            animal.AddFeedRecord(feedRecord);

            await _animalRepo.UpdateAsync(animal);

            return feedRecord.Id;
        }
    }
}
