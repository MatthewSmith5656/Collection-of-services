using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ServiceBusTrigger.Application.Models
{
    public class QueueMessage : Entity
    {
        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("keyValuePairs")]
        public IDictionary<int, string> KeyValuePairs { get; set; }
    }
}