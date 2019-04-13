using Android.App;
using Android.Content;
using Android.Runtime;
using MvvmCross.Platform;
using MvvmCross.Platform.Droid.Platform;
using System;
using Zadania.Core.Services;

namespace Zadania.Android.Services
{
    public class AndroidScheduledNotificationService : IScheduledNotificationService
    {
        public static long GenerateNotifcationTimeStamp(DateTime startDate)
        {
            var schedule = startDate;
            Java.Util.Calendar calendar = Java.Util.Calendar.Instance;
            calendar.Set(Java.Util.CalendarField.HourOfDay, schedule.Hour);
            calendar.Set(Java.Util.CalendarField.Minute, schedule.Minute);
            calendar.Set(Java.Util.CalendarField.Second, 00);
            return calendar.TimeInMillis;
        }

        public void AddNotification(DateTime startDate, string content)
        {
            var currentActivity = Mvx.Resolve<IMvxAndroidCurrentTopActivity>();
            var context = currentActivity.Activity.BaseContext;

            Intent alarmIntent = new Intent(context, typeof(AlarmReceiverService));
            alarmIntent.PutExtra("Content", content);
            PendingIntent pending = PendingIntent.GetBroadcast(context, 0, alarmIntent, PendingIntentFlags.UpdateCurrent);
            AlarmManager alarmManager = context.GetSystemService("alarm").JavaCast<AlarmManager>();
            alarmManager.Set(AlarmType.RtcWakeup, GenerateNotifcationTimeStamp(startDate), pending);
        }
    }
}