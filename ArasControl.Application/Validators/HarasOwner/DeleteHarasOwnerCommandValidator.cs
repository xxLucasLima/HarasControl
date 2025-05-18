using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArasControl.Application.Commands.HarasOwner;
using FluentValidation;

namespace ArasControl.Application.Validators.HarasOwner
{
    public class DeleteHarasOwnerCommandValidator : AbstractValidator<DeleteHarasOwnerCommand>
    {
        public DeleteHarasOwnerCommandValidator()
        {
            RuleFor(x => x.Id).NotEqual(Guid.Empty);
        }
    }
}
