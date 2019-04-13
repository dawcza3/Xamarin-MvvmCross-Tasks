using System;

namespace Zadania.Core.Services
{
    public interface IScheduledNotificationService
    {
        void AddNotification(DateTime startDate, string content);
    }
}
