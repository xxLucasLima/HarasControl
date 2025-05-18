using ArasControl.Domain.Interfaces;
using MediatR;

namespace ArasControl.Application.Commands.Haras.Handler
{
    public class CreateHarasHandler(IHarasRepository harasRepo) : IRequestHandler<CreateHarasCommand, Guid>
    {
        private readonly IHarasRepository _harasRepo = harasRepo;

        public async Task<Guid> Handle(CreateHarasCommand request, CancellationToken cancellationToken)
        {
            var haras = new Domain.Entities.Haras(Guid.NewGuid(), request.Name, request.OwnerId);
            await _harasRepo.AddAsync(haras);
            return haras.Id;
        }
    }
}