
using MediatR;

namespace ArasControl.Application.Commands.Haras
{
    public class CreateHarasCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public Guid OwnerId { get; set; }

        public CreateHarasCommand(string name, Guid ownerId)
        {
            Name = name;
            OwnerId = ownerId;
        }
    }
}
