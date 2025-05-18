using ArasControl.Application.Commands.FeedInventory;
using FluentValidation;

namespace ArasControl.Application.Validators.FeedInventory
{
    public class UpdateFeedInventoryCommandValidator : AbstractValidator<UpdateFeedInventoryCommand>
    {
        public UpdateFeedInventoryCommandValidator()
        {
            RuleFor(x => x.Id).NotEqual(Guid.Empty);
            RuleFor(x => x.CurrentQuantity).GreaterThanOrEqualTo(0);
            RuleFor(x => x.Unit).NotEmpty().MaximumLength(20);
            RuleFor(x => x.ThresholdQuantity).GreaterThanOrEqualTo(0);
        }
    }
}
