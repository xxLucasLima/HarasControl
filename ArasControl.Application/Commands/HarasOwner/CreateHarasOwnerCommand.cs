using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace ArasControl.Application.Commands.HarasOwner
{
    public class CreateHarasOwnerCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public CreateHarasOwnerCommand(string name, string email)
        {
            Name = name;
            Email = email;
        }
    }
}
