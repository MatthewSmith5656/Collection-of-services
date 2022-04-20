using FunctionApps.Application.Models;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace FunctionApps.Application.Interfaces
{
    public interface IQueueService
    {
        Task ProcessQueueMessage(ILogger log, QueueMessage queueMessage);
    }
}