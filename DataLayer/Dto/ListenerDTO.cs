using DataLayer.Enums;
using DataLayer.Interfaces;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Dto
{
    public class ListenerDTO : IMediaObject
    {

        public string Name { get; set; }
        public TimeSpan TotalListeningTime { get;  set; }
        public SubscriptionType Subscription { get; set; }
  


        internal ListenerDTO(Listener listener)
        {
            Name = listener.Name;
            TotalListeningTime = listener.TotalListeningTime;
            Subscription = listener.Subscription;
        }

        public ListenerDTO() { }


   
    }
}
