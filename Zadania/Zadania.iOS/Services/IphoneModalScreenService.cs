using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Zadania.Core.Services;

namespace Zadania.iOS.Services
{
    public class IphoneModalScreenService : IModalScreenService
    {
        public void ConfirmAdditionalAction(string title, string content, Action confirmAction, Action cancelAction)
        {
            var alertController = UIAlertController.Create(title, content, UIAlertControllerStyle.Alert);

            alertController.AddAction(UIAlertAction.Create("Tak", UIAlertActionStyle.Default, delegate
            {
                confirmAction();
            }));

            alertController.AddAction(UIAlertAction.Create("Nie", UIAlertActionStyle.Cancel, delegate
            {
                cancelAction();
            }));

            UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(alertController, true, null);

            //((AppDelegate)UIApplication.SharedApplication.Delegate)
            //    .Window.RootViewController.PresentViewController(alertController, true, null);
        }
    }
}