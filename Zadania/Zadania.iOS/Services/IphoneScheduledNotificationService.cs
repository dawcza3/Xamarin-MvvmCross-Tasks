using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Zadania.Core.Services;

namespace Zadania.iOS.Services
{
    public class IphoneScheduledNotificationService : IScheduledNotificationService
    {
        public void AddNotification(DateTime startDate, string content)
        {
            var secondsDiffrence = (startDate - DateTime.Now).TotalSeconds;
            var notification = new UILocalNotification();

            notification.FireDate = NSDate.FromTimeIntervalSinceNow(secondsDiffrence);
            notification.AlertAction = "Twoje Zadanie!";
            notification.AlertBody = content;
            notification.ApplicationIconBadgeNumber = 1;
            notification.SoundName = UILocalNotification.DefaultSoundName;

            UIApplication.SharedApplication.ScheduleLocalNotification(notification);
        }
    }
}