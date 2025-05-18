using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArasControl.Application.Commands.Haras;
using FluentValidation;

namespace ArasControl.Application.Validators.Haras
{
    public class DeleteHarasCommandValidator : AbstractValidator<DeleteHarasCommand>
    {
        public DeleteHarasCommandValidator()
        {
            RuleFor(x => x.Id).NotEqual(Guid.Empty);
        }
    }
}
