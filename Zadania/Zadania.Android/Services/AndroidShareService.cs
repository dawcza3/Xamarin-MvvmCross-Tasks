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
using MvvmCross.Platform;
using MvvmCross.Platform.Droid.Platform;
using Zadania.Core.Services;

namespace Zadania.Android.Services
{
    public class AndroidShareService : IShareService
    {
        public void Share(string content)
        {
            var currentActivity = Mvx.Resolve<IMvxAndroidCurrentTopActivity>();

            Intent sharingIntent = new Intent(Intent.ActionSend);
            sharingIntent.SetType("text/plain");
            sharingIntent.PutExtra(Intent.ExtraSubject, "subject");
            sharingIntent.PutExtra(Intent.ExtraText, content);
            sharingIntent.PutExtra(Intent.ExtraTitle, "Zadanie do wykonania");

            currentActivity.Activity.StartActivity(Intent.CreateChooser(sharingIntent,"Udostępnij za pomocą"));
        }
    }
}