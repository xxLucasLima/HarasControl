using MediatR;

namespace ArasControl.Application.Commands.AnimalOwner
{
    public class CreateAnimalOwnerCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public Guid HarasId { get; set; }

        public CreateAnimalOwnerCommand(string name, string email, Guid harasId)
        {
            Name = name;
            Email = email;
            HarasId = harasId;
        }
    }
}
