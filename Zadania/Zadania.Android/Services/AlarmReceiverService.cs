using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Zadania.Android.Views;

namespace Zadania.Android.Services
{
    [BroadcastReceiver]
    public class AlarmReceiverService : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            var title = "Zadanie do Wykonania!";
            var message = intent.GetStringExtra("Content");

            Intent backIntent = new Intent(context, typeof(MainView));
            backIntent.SetFlags(ActivityFlags.NewTask);

            var resultIntent = new Intent(context, typeof(MainView));

            PendingIntent pending = PendingIntent.GetActivities(context, 0,
                new Intent[] { backIntent, resultIntent },
                PendingIntentFlags.OneShot);

            var builder =
                new Notification.Builder(context)
                    .SetContentTitle(title)
                    .SetContentText(message)
                    .SetAutoCancel(true)
                    .SetSmallIcon(Resource.Mipmap.Icon)
                    .SetDefaults(NotificationDefaults.All);

            builder.SetContentIntent(pending);
            var notification = builder.Build();
            var manager = NotificationManager.FromContext(context);
            manager.Notify(1331, notification);
        }
    }
}