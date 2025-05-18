using ArasControl.Domain.Interfaces;
using MediatR;

namespace ArasControl.Application.Commands.HarasOwner.Handler
{
    public class UpdateHarasOwnerHandler : IRequestHandler<UpdateHarasOwnerCommand, Unit>
    {
        private readonly IHarasOwnerRepository _repo;

        public UpdateHarasOwnerHandler(IHarasOwnerRepository repo)
        {
            _repo = repo;
        }

        public async Task<Unit> Handle(UpdateHarasOwnerCommand request, CancellationToken cancellationToken)
        {
            var owner = await _repo.GetByIdAsync(request.Id);
            if (owner == null)
                throw new Exception("HarasOwner não encontrado.");

            owner.UpdateContact(request.Name, request.Email);

            await _repo.UpdateAsync(owner);
            return Unit.Value;
        }
    }
}
