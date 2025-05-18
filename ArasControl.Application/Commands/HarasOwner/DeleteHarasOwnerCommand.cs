using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace ArasControl.Application.Commands.HarasOwner
{
    public class DeleteHarasOwnerCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }

        public DeleteHarasOwnerCommand(Guid id)
        {
            Id = id;
        }
    }
}
