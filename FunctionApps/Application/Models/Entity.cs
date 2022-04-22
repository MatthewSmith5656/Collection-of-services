using System;
using System.Text.Json.Serialization;

namespace FunctionApps.Application.Models
{
    public class Entity
    {
        [JsonPropertyName ("id")]
        public string Id { get; set; }

        [JsonPropertyName("createdOn")]
        public DateTime CreatedOn { get; set; }

        [JsonPropertyName("createdBy")]
        public string CreatedBy { get; set; }

        [JsonPropertyName("isProcessed")]
        public bool IsProcessed { get; set; }
    }
}