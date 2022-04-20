using System;

namespace FunctionApps.Application.Models
{
    public class Entity
    {
        public string Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public bool IsProcessed { get; set; }
    }
}