using ArasControl.Domain.Interfaces;
using MediatR;

namespace ArasControl.Application.Commands.Haras.Handler
{
    public class DeleteHarasHandler : IRequestHandler<DeleteHarasCommand, Unit>
    {
        private readonly IHarasRepository _harasRepo;

        public DeleteHarasHandler(IHarasRepository harasRepo)
        {
            _harasRepo = harasRepo;
        }

        public async Task<Unit> Handle(DeleteHarasCommand request, CancellationToken cancellationToken)
        {
            var haras = await _harasRepo.GetByIdAsync(request.Id);
            if (haras == null)
                throw new Exception("Haras não encontrado.");

            await _harasRepo.RemoveAsync(haras);
            return Unit.Value;
        }
    }
}
