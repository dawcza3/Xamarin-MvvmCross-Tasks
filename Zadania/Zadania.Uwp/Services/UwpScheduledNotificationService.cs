using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Notifications;
using Zadania.Core.Services;

namespace Zadania.Uwp.Services
{
    public class UwpScheduledNotificationService : IScheduledNotificationService
    {
        public void AddNotification(DateTime startDate, string content)
        {
            Windows.Data.Xml.Dom.XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastText02);
            Windows.Data.Xml.Dom.XmlNodeList toastNodeList = toastXml.GetElementsByTagName("text");
            toastNodeList.Item(0).AppendChild(toastXml.CreateTextNode("Zadanie do wykonania\n"));
            toastNodeList.Item(1).AppendChild(toastXml.CreateTextNode(content));
            Windows.Data.Xml.Dom.IXmlNode toastNode = toastXml.SelectSingleNode("/toast");
            Windows.Data.Xml.Dom.XmlElement audio = toastXml.CreateElement("audio");
            audio.SetAttribute("src", "ms-winsoundevent:Notification.SMS");

            var diffrence = (startDate - DateTime.Now).TotalSeconds;

            DateTime EventDate = DateTime.Now.AddSeconds(diffrence);
            TimeSpan NotTime = EventDate.Subtract(DateTime.Now);
            DateTime dueTime = DateTime.Now.Add(NotTime);

            ScheduledToastNotification scheduledToast = new ScheduledToastNotification(toastXml, dueTime);
            ToastNotificationManager.CreateToastNotifier().AddToSchedule(scheduledToast);
        }
    }
}
