using System;

namespace SignalRSample.Models
{
    public class UserPromotion
    {
        public Guid PromotionGuid { get; set; }

        public string UserId { get; set; }

        public DateTime SentDateTime { get; set; }

        public bool IsDelivered { get; set; }

        public DateTime? DeliveredDateTime { get; set; }

        public bool IsRead { get; set; }

        public DateTime? ReadDateTime { get; set; }
    }
}
