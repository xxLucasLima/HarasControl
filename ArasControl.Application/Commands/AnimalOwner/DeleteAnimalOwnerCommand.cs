using MediatR;

namespace ArasControl.Application.Commands.AnimalOwner
{
    public class DeleteAnimalOwnerCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }

        public DeleteAnimalOwnerCommand(Guid id)
        {
            Id = id;
        }
    }
}
