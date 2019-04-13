using Android.App;
using Android.OS;
using Android.Widget;
using MvvmCross.Droid.Views;
using System;

namespace Zadania.Android.Views
{
    [Activity(Label = "Zadania")]
    public class MainView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.MainView);
        }
    }
}
