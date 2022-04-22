using Microsoft.Extensions.Logging;
using ServiceBusTrigger.Application.Models;
using System.Threading.Tasks;

namespace ServiceBusTrigger.Application.Interfaces
{
    public interface IQueueService
    {
        Task ProcessQueueMessage(ILogger log, QueueMessage queueMessage);
    }
}