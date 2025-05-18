using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArasControl.Domain.Interfaces;
using MediatR;

namespace ArasControl.Application.Commands.HarasOwner.Handler
{
    public class CreateHarasOwnerHandler : IRequestHandler<CreateHarasOwnerCommand, Guid>
    {
        private readonly IHarasOwnerRepository _repo;

        public CreateHarasOwnerHandler(IHarasOwnerRepository repo)
        {
            _repo = repo;
        }

        public async Task<Guid> Handle(CreateHarasOwnerCommand request, CancellationToken cancellationToken)
        {
            var owner = new Domain.Entities.HarasOwner(Guid.NewGuid(), request.Name, request.Email);
            await _repo.AddAsync(owner);
            return owner.Id;
        }
    }
}
