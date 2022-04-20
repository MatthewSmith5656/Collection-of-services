using System.Collections.Generic;

namespace FunctionApps.Application.Models
{
    public class QueueMessage : Entity
    {
        public string Message { get; set; }
        public IDictionary<int, string> KeyValuePairs { get; set; }
    }
}