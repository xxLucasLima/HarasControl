using MediatR;

namespace ArasControl.Application.Commands.Animal
{
    public class DeleteAnimalCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }

        public DeleteAnimalCommand(Guid id)
        {
            Id = id;
        }
    }
}
