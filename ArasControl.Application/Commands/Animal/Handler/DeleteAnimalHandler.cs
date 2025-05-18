using ArasControl.Domain.Interfaces;
using MediatR;

namespace ArasControl.Application.Commands.Animal.Handler
{
    public class DeleteAnimalHandler : IRequestHandler<DeleteAnimalCommand, Unit>
    {
        private readonly IAnimalRepository _animalRepo;

        public DeleteAnimalHandler(IAnimalRepository animalRepo)
        {
            _animalRepo = animalRepo;
        }

        public async Task<Unit> Handle(DeleteAnimalCommand request, CancellationToken cancellationToken)
        {
            var animal = await _animalRepo.GetByIdAsync(request.Id);
            if (animal == null)
                throw new Exception("Animal não encontrado.");

            await _animalRepo.RemoveAsync(animal);
            return Unit.Value;
        }
    }
}
