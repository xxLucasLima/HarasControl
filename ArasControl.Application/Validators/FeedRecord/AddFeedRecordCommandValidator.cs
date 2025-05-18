using ArasControl.Application.Commands.FeedRecord;
using FluentValidation;

namespace ArasControl.Application.Validators.FeedRecord
{
    public class AddFeedRecordCommandValidator : AbstractValidator<AddFeedRecordCommand>
    {
        public AddFeedRecordCommandValidator()
        {
            RuleFor(x => x.AnimalId).NotEqual(Guid.Empty);
            RuleFor(x => x.Amount).GreaterThan(0);
            RuleFor(x => x.Unit).NotEmpty().MaximumLength(20);
            RuleFor(x => x.FedAt).LessThanOrEqualTo(DateTime.UtcNow);
            RuleFor(x => x.Notes).MaximumLength(300);
        }
    }
}
