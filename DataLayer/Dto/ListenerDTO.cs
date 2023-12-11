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
  
        public string Id { get; set; }

        internal ListenerDTO(User listener)
        {
            Name = listener.Name;
            TotalListeningTime = listener.TotalListeningTime;
            Subscription = listener.Subscription;
            Id = listener.Id;
        }

        public ListenerDTO() { }


   
    }
}
