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
    public class AndroidModalScreenService : IModalScreenService
    {
        public void ConfirmAdditionalAction(string title, string content, Action confirmAction, Action cancelAction)
        {
            var currentActivity = Mvx.Resolve<IMvxAndroidCurrentTopActivity>();

            var popup = new AlertDialog.Builder(currentActivity.Activity).Create();

            popup.SetTitle(title);
            popup.SetMessage(content);
            popup.SetButton("Tak", (s, a) => { confirmAction(); });
            popup.SetButton2("Nie", (s, a) => { cancelAction(); });

            popup.Show();
        }
    }
}