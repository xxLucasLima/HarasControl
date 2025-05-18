
using ArasControl.Domain.Interfaces;
using MediatR;

namespace ArasControl.Application.Commands.Haras.Handler
{
    public class UpdateHarasHandler(IHarasRepository harasRepo) : IRequestHandler<UpdateHarasCommand, Unit>
    {
        private readonly IHarasRepository _harasRepo = harasRepo;

        public async Task<Unit> Handle(UpdateHarasCommand request, CancellationToken cancellationToken)
        {
            var haras = await _harasRepo.GetByIdAsync(request.Id);
            if (haras == null)
                throw new Exception("Haras não encontrado.");

            haras.Rename(request.Name);

            await _harasRepo.UpdateAsync(haras);
            return Unit.Value;
        }
    }
}
