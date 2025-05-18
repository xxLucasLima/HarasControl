using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace ArasControl.Application.Commands.AnimalOwner
{
    public class UpdateAnimalOwnerCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Guid HarasId { get; set; }

        public UpdateAnimalOwnerCommand(Guid id, string name, string email, Guid harasId)
        {
            Id = id;
            Name = name;
            Email = email;
            HarasId = harasId;
        }
    }
}
