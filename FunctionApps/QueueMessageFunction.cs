using FunctionApps.Application.Interfaces;
using FunctionApps.Application.Models;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ServiceBusTrigger.Application.Validator;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FunctionApps
{
    public class QueueMessageFunction
    {
    private readonly IQueueService _queueService;
    public QueueMessageFunction(IQueueService queueService)
    {
        _queueService = queueService;
    }
        private QueueMessage queueMessageToLog;

        [FunctionName("TriggerA")]
        public async Task<bool> Run([ServiceBusTrigger("devqueue", Connection = "")]string myQueueItem, ILogger _log)
        {
            var validator = new QueueMessageValidator();
            try
            {
                QueueMessage queueMessage = JsonConvert.DeserializeObject<QueueMessage>(myQueueItem);
                queueMessageToLog = queueMessage;
                var validationResult = validator.Validate(queueMessage);
                if (!validationResult.IsValid)
                {
                  var error = validationResult.Errors.Select(e => new {
                        Field = e.PropertyName,
                        Error = e.ErrorMessage
                    });
                    throw new Exception(QueueExceptions.invalidRequest.ToString(), (Exception)error);
                }
                await _queueService.ProcessQueueMessage(_log, queueMessage);
            }
            catch(Exception e)
            {
                var x = e;
                _log.LogError($"C# ServiceBus queue trigger failed function processed message: {queueMessageToLog} \\n error :  " + e);
                return false;
            }
            _log.LogInformation($"C# ServiceBus queue trigger function processed message: {queueMessageToLog}");
            return true;
        }
    }
}
