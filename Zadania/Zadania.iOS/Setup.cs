using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Platform;
using MvvmCross.iOS.Views.Presenters;
using MvvmCross.Platform;
using MvvmCross.Platform.Platform;
using UIKit;
using Zadania.Core.Services;
using Zadania.iOS.Services;

namespace Zadania.iOS
{
    public class Setup : MvxIosSetup
    {
        public Setup(IMvxApplicationDelegate applicationDelegate, UIWindow window)
            : base(applicationDelegate, window)
        {

        }

        public Setup(IMvxApplicationDelegate applicationDelegate, IMvxIosViewPresenter presenter)
            : base(applicationDelegate, presenter)
        {
        }

        protected override void InitializePlatformServices()
        {
            base.InitializePlatformServices();
            Mvx.RegisterType<IModalScreenService, IphoneModalScreenService>();
            Mvx.RegisterType<IShareService, IphoneShareService>();
            Mvx.RegisterType<IScheduledNotificationService, IphoneScheduledNotificationService>();
        }

        protected override IMvxApplication CreateApp() => new Core.App();

        protected override IMvxTrace CreateDebugTrace() => new DebugTrace();
    }
}
