using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArasControl.Application.Commands.AnimalOwner;
using FluentValidation;

namespace ArasControl.Application.Validators.AnimalOwner
{
    public class UpdateAnimalOwnerCommandValidator : AbstractValidator<UpdateAnimalOwnerCommand>
    {
        public UpdateAnimalOwnerCommandValidator()
        {
            RuleFor(x => x.Id).NotEqual(Guid.Empty);
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Email).NotEmpty().MaximumLength(200).EmailAddress();
            RuleFor(x => x.HarasId).NotEqual(Guid.Empty);
        }
    }
}
