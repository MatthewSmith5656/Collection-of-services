using System.Collections.Generic;

namespace FunctionApps.Application.Models
{
    public class QueueMessage : Entity
    {
        public string message { get; set; }
        public IDictionary<int, string> keyValuePairs { get; set; }
    }
}