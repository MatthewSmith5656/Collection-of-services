using Microsoft.Extensions.Logging;
using ServiceBusTrigger.Application.Interfaces;
using ServiceBusTrigger.Application.Models;
using ServiceBusTrigger.Application.Models.Enums;
using System;
using System.Threading.Tasks;

namespace ServiceBusTrigger.Application.Services
{
    public class QueueService : IQueueService
    {
        public Task ProcessQueueMessage(ILogger log, QueueMessage queueMessage)
        {
            if (!queueMessage.IsProcessed)
            {
                throw new Exception(QueueExceptions.isProcessed.ToString());
            }
            if (!Guid.TryParse(queueMessage.Id, out _))
            {
                throw new Exception(QueueExceptions.idInvalid.ToString());
            }
            throw new NotImplementedException();
        }
    }
}