using FunctionApps.Application.Models;
using ServiceBusTrigger.Application.Validator;
using System;
using Xunit;

namespace TestProject
{
    public class ModelValidationShould
    {
        private QueueMessage queueMessage = new QueueMessage()
        {
            Id = new Guid().ToString(),
            CreatedBy = "George",
            CreatedOn = DateTime.UtcNow,
            IsProcessed = false,
            KeyValuePairs = null,
            Message = "Hello Wordl!"
        };

        [Fact]
        public void QueueMessageValid()
        {
            var validator = new QueueMessageValidator();
            var validationResult = validator.Validate(queueMessage);
            Assert.True(validationResult.IsValid);
        }

        [Fact]
        public void QueueMessageIdInValid()
        {
        queueMessage.Id = null;
        var validator = new QueueMessageValidator();
        var validationResult = validator.Validate(queueMessage);
        Assert.True(!validationResult.IsValid);
        }

        [Fact]
        public void QueueMessageMessageInValid()
        {
            queueMessage.Message = null;
            var validator = new QueueMessageValidator();
            var validationResult = validator.Validate(queueMessage);
            Assert.True(!validationResult.IsValid);
        }
    }
}