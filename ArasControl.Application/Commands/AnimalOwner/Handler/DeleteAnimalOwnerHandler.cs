using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArasControl.Domain.Interfaces;
using MediatR;

namespace ArasControl.Application.Commands.AnimalOwner.Handler
{
    public class DeleteAnimalOwnerHandler : IRequestHandler<DeleteAnimalOwnerCommand, Unit>
    {
        private readonly IAnimalOwnerRepository _repo;

        public DeleteAnimalOwnerHandler(IAnimalOwnerRepository repo)
        {
            _repo = repo;
        }

        public async Task<Unit> Handle(DeleteAnimalOwnerCommand request, CancellationToken cancellationToken)
        {
            var owner = await _repo.GetByIdAsync(request.Id);
            if (owner == null)
                throw new Exception("AnimalOwner não encontrado.");

            await _repo.RemoveAsync(owner);
            return Unit.Value;
        }
    }
}
