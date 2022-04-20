using FunctionApps;
using FunctionApps.Application.Interfaces;
using FunctionApps.Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestProject
{
    public class QueueMessageFunctionShould
    {
        private static Dictionary<int, string> kvp = new Dictionary<int, string>();
        private readonly Mock<ILogger<QueueService>> _logger = new();
        private readonly Mock<IQueueService> _queueService = new();
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
        public async void ProcessMessage_Valid()
        {
            var message = JsonConvert.SerializeObject(new
            {
                Id = new Guid().ToString(),
                CreatedBy = "George",
                CreatedOn = DateTime.UtcNow,
                IsProcessed = false,
                KeyValuePairs = kvp,
                Message = "Hello Wordl!"
            });
            var function = new QueueMessageFunction(_queueService.Object);
            Assert.True(await function.Run(message, _logger.Object));
        }

        [Fact]
        public async void ProcessMessage_Invalid_Deserilization()
        {
            QueueMessage message = new QueueMessage()
            {
                Id = new Guid().ToString(),
                CreatedBy = "George",
                CreatedOn = DateTime.UtcNow,
                IsProcessed = false,
                KeyValuePairs = null,
                Message = "Hello Wordl!"
            };

            var function = new QueueMessageFunction(_queueService.Object);
            Assert.False(await function.Run(message.ToString(), _logger.Object));
        }

        [Fact]
        public async void ProcessMessage_Invalid_IdEmpty()
        {
            var message = JsonConvert.SerializeObject(new
            {
                Id = "",
                CreatedBy = "George",
                CreatedOn = DateTime.UtcNow,
                IsProcessed = false,
                KeyValuePairs = kvp,
                Message = "Hello Wordl!"
            });
            var function = new QueueMessageFunction(_queueService.Object);
            Assert.False(await function.Run(message, _logger.Object));
        }
    }
}

