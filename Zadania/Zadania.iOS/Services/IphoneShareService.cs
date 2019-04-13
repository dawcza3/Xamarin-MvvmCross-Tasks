using Foundation;
using System;
using System.Collections.Generic;
using System.Text;
using UIKit;
using Zadania.Core.Services;

namespace Zadania.iOS.Services
{
    public class IphoneShareService : IShareService
    {
        public void Share(string content)
        {
            var text = NSObject.FromObject(content);
            var items = new[] { text };
            var controller = new UIActivityViewController(items, null);
            UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(controller, true, null);
        }
    }
}
