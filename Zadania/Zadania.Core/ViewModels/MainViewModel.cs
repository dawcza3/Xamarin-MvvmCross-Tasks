using System;
using MvvmCross.Core.ViewModels;
using Zadania.Core.Services;

namespace Zadania.Core.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        private readonly IShareService _shareService;
        private readonly IModalScreenService _popupService;
        private readonly IScheduledNotificationService _scheduledNotificationService;

        public MainViewModel(IScheduledNotificationService scheduledNotificationService,
            IShareService shareService, IModalScreenService popupService)
        {
            _scheduledNotificationService = scheduledNotificationService;
            _shareService = shareService;
            _popupService = popupService;
        }


        private DateTime _date = DateTime.Now;
        public DateTime Date
        {
            get { return _date; }
            set { SetProperty(ref _date, value); }
        }

        private TimeSpan _time = new TimeSpan(0, 0, 0);
        public TimeSpan Time
        {
            get { return _time; }
            set { SetProperty(ref _time, value); }
        }

        private string _work = "";
        public string Work
        {
            get { return _work; }
            set { SetProperty(ref _work, value); }
        }

        public IMvxCommand AddWorkCommand => new MvxCommand(() =>
        {
            _scheduledNotificationService.AddNotification(
                new DateTime(_date.Year, _date.Month, _date.Day, _time.Hours, _time.Minutes, 0),
                _work);
            _popupService.ConfirmAdditionalAction("Twoje zadanie zosta³o zapisane",
                "Czy chcesz udostêpniæ swoje zadanie?", () => { ConfirmShare(); }, () => { SetDefaultValues(); });
        });

        private void ConfirmShare()
        {
            _shareService.Share("Zadanie do wykonania:\n" + Work +
                " dnia: " + Date.ToString("dd.mm.yyyy"));
            SetDefaultValues();
        }

        private void SetDefaultValues()
        {
            Date = DateTime.Now;
            Time = new TimeSpan(0, 0, 0);
            Work = "";
        }

    }
}