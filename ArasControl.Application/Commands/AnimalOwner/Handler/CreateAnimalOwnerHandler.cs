using ArasControl.Domain.Interfaces;
using MediatR;

namespace ArasControl.Application.Commands.AnimalOwner.Handler
{
    public class CreateAnimalOwnerHandler : IRequestHandler<CreateAnimalOwnerCommand, Guid>
    {
        private readonly IAnimalOwnerRepository _repo;

        public CreateAnimalOwnerHandler(IAnimalOwnerRepository repo)
        {
            _repo = repo;
        }

        public async Task<Guid> Handle(CreateAnimalOwnerCommand request, CancellationToken cancellationToken)
        {
            var owner = new Domain.Entities.AnimalOwner(Guid.NewGuid(), request.Name, request.Email, request.HarasId);
            await _repo.AddAsync(owner);
            return owner.Id;
        }
    }
}
