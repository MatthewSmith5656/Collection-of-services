using FluentValidation;
using FunctionApps.Application.Models;

namespace ServiceBusTrigger.Application.Validator
{
    public class QueueMessageValidator : AbstractValidator<QueueMessage>
    {
        public QueueMessageValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.IsProcessed).NotEmpty();
            RuleFor(x => x.message).NotEmpty().MaximumLength(256);
        }
    }
}
