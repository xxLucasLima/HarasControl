using ArasControl.Application.Commands.FeedInventory;
using FluentValidation;

namespace ArasControl.Application.Validators.FeedInventory
{
    public class CreateFeedInventoryCommandValidator : AbstractValidator<CreateFeedInventoryCommand>
    {
        public CreateFeedInventoryCommandValidator()
        {
            RuleFor(x => x.AnimalId).NotEqual(Guid.Empty);
            RuleFor(x => x.CurrentQuantity).GreaterThanOrEqualTo(0);
            RuleFor(x => x.Unit).NotEmpty().MaximumLength(20);
            RuleFor(x => x.ThresholdQuantity).GreaterThanOrEqualTo(0);
        }
    }
}
