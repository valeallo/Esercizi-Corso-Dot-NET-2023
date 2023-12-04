using DataLayer.Enums;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Dto
{
    public class ListenerDTO
    {

        public string Name { get; set; }
        public TimeSpan TotalListeningTime { get; private set; }
        public SubscriptionType Subscription { get; set; }
        private const int MaxListeningTimeFree = 100;
        private const int MaxListeningTimePremium = 1000;


        public ListenerDTO(Listener listener)
        {
            Name = listener.Name;
            TotalListeningTime = listener.TotalListeningTime;
            Subscription = listener.Subscription;
        }

        public ListenerDTO() { }


        public bool CanListen()
        {
            switch (Subscription)
            {
                case SubscriptionType.Free:
                    return TotalListeningTime.TotalHours < MaxListeningTimeFree;
                case SubscriptionType.Premium:
                    return TotalListeningTime.TotalHours < MaxListeningTimePremium;
                case SubscriptionType.Gold:
                    return true;
                default:
                    return false;
            }
        }
    }
}
