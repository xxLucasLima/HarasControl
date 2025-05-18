using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace ArasControl.Application.Commands.Haras
{
    public class DeleteHarasCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }

        public DeleteHarasCommand(Guid id)
        {
            Id = id;
        }
    }
}
