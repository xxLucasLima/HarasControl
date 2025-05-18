using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArasControl.Domain.Interfaces;
using MediatR;

namespace ArasControl.Application.Commands.AnimalOwner.Handler
{
    public class UpdateAnimalOwnerHandler : IRequestHandler<UpdateAnimalOwnerCommand, Unit>
    {
        private readonly IAnimalOwnerRepository _repo;

        public UpdateAnimalOwnerHandler(IAnimalOwnerRepository repo)
        {
            _repo = repo;
        }

        public async Task<Unit> Handle(UpdateAnimalOwnerCommand request, CancellationToken cancellationToken)
        {
            var owner = await _repo.GetByIdAsync(request.Id);
            if (owner == null)
                throw new Exception("AnimalOwner não encontrado.");

            owner.UpdateContact(request.Name, request.Email);
            owner.ChangeHaras(request.HarasId);

            await _repo.UpdateAsync(owner);
            return Unit.Value;
        }
    }
}
