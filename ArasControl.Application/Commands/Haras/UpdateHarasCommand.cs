using MediatR;

namespace ArasControl.Application.Commands.Haras
{
    public class UpdateHarasCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public UpdateHarasCommand(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
