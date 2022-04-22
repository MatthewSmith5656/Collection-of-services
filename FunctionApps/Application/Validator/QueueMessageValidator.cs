using FluentValidation;
using ServiceBusTrigger.Application.Models;

namespace ServiceBusTrigger.Application.Validator
{
    public class QueueMessageValidator : AbstractValidator<QueueMessage>
    {
        public QueueMessageValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.IsProcessed).NotNull();
            RuleFor(x => x.Message).NotEmpty().MaximumLength(256);
        }
    }
}
