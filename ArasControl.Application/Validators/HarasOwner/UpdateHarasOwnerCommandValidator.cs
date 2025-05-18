﻿using ArasControl.Application.Commands.HarasOwner;
using FluentValidation;

namespace ArasControl.Application.Validators.HarasOwner
{
    public class UpdateHarasOwnerCommandValidator : AbstractValidator<UpdateHarasOwnerCommand>
    {
        public UpdateHarasOwnerCommandValidator()
        {
            RuleFor(x => x.Id).NotEqual(Guid.Empty);
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Email).NotEmpty().MaximumLength(200).EmailAddress();
        }
    }
}
