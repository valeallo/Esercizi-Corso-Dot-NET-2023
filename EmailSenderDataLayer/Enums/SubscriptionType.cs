using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSenderDataLayer.Enums
{
    public enum SubscriptionType
    {
        Free,
        Premium,
        Gold
    }
    public class SubscriptionSettings
    {
        public static readonly Dictionary<SubscriptionType, int> MaxListeningTimes = new Dictionary<SubscriptionType, int>
        {
            { SubscriptionType.Free, 100 },
            { SubscriptionType.Premium, 1000 },
            { SubscriptionType.Gold, Int32.MaxValue } 
        };
    }
}
