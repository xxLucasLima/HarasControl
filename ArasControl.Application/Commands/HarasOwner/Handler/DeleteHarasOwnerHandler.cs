using ArasControl.Domain.Interfaces;
using MediatR;

namespace ArasControl.Application.Commands.HarasOwner.Handler
{
    public class DeleteHarasOwnerHandler : IRequestHandler<DeleteHarasOwnerCommand, Unit>
    {
        private readonly IHarasOwnerRepository _repo;

        public DeleteHarasOwnerHandler(IHarasOwnerRepository repo)
        {
            _repo = repo;
        }

        public async Task<Unit> Handle(DeleteHarasOwnerCommand request, CancellationToken cancellationToken)
        {
            var owner = await _repo.GetByIdAsync(request.Id);
            if (owner == null)
                throw new Exception("HarasOwner não encontrado.");

            await _repo.RemoveAsync(owner);
            return Unit.Value;
        }
    }
}
