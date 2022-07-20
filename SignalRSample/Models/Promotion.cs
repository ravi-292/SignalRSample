using System;

namespace SignalRSample.Models
{
    public class Promotion
    {
        public Guid Guid { get; set; }

        public string Type { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
    }
}
