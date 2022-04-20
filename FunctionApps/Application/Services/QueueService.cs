using FunctionApps.Application.Interfaces;
using FunctionApps.Application.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace FunctionApps
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
                throw new Exception(QueueExceptions.invalidRequest.ToString());
            }
            throw new System.NotImplementedException();
        }
    }
}