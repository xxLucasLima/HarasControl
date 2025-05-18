using MediatR;

namespace ArasControl.Application.Commands.HarasOwner
{
    public class UpdateHarasOwnerCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public UpdateHarasOwnerCommand(Guid id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
        }
    }
}
