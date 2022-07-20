using SignalRSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRSample.Storage
{
    public static class DummyStorage
    {
        public static List<Promotion> Promotions { get; set; } = new List<Promotion>();

        public static List<UserPromotion> UserPromotions { get; set; } = new List<UserPromotion>();
    }
}
