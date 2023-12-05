using DataLayer.Dto;
using DataLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class UserService
    {
        PlayerService playerService;
        ListenerDTO _user;
        public UserService(PlayerService PlayerService)
        {
            playerService = PlayerService;
            _user = PlayerService.GetAllListeners()[0];
        }

        public ListenerDTO User { get {return _user;} }
        public SubscriptionType Subscription { get { return _user.Subscription;  } }
        public TimeSpan TotalListeningTime {  get { return _user.TotalListeningTime; } }
        public void Login(string listenerName)
        {
            List<ListenerDTO> allListeners = playerService.GetAllListeners();
            ListenerDTO listener = allListeners.FirstOrDefault(l => l.Name.Equals(listenerName, StringComparison.OrdinalIgnoreCase));
            Console.WriteLine(listener);
            _user = listener;
        }

        public bool CanListen()
        {
            switch (Subscription)
            {
                case SubscriptionType.Free:
                    return _user.TotalListeningTime.TotalHours < SubscriptionSettings.MaxListeningTimes[SubscriptionType.Free];
                case SubscriptionType.Premium:
                    return _user.TotalListeningTime.TotalHours < SubscriptionSettings.MaxListeningTimes[SubscriptionType.Premium];
                case SubscriptionType.Gold:
                    return true;
                default:
                    return false;
            }
        }



        public int MaxListeningTime
        {
            get
            {
                if (Subscription == SubscriptionType.Gold)
                {
                    return int.MaxValue; 
                }
                else
                {
                    return SubscriptionSettings.MaxListeningTimes[Subscription];
                }
            }
        }



    }
}
