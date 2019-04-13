using Android.Content;
using MvvmCross.Droid.Platform;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.Platform;
using Zadania.Android.Services;
using Zadania.Core.Services;
using MvvmCross.Platform;

namespace Zadania.Android
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext) : base(applicationContext)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new Core.App();
        }

        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }

        protected override void InitializePlatformServices()
        {
            base.InitializePlatformServices();
            Mvx.RegisterType<IModalScreenService, AndroidModalScreenService>();
            Mvx.RegisterType<IShareService, AndroidShareService>();
            Mvx.RegisterType<IScheduledNotificationService, AndroidScheduledNotificationService>();
        }
    }
}
