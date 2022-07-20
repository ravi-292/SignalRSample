using System;
using System.Collections.Generic;

namespace SignalRSample.Models
{
    public class PromotionViewModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public List<string> Recipients { get; set; }

        public List<Promotion> Promotions { get; set; }
    }
}
