using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Platform.Logging;
using MvvmCross.Uwp.Platform;
using Windows.UI.Xaml.Controls;
using Zadania.Core.Services;
using Zadania.Uwp.Services;

namespace Zadania.Uwp
{
    public class Setup : MvxWindowsSetup
    {
        public Setup(Frame rootFrame) : base(rootFrame)
        {
        }

        protected override IMvxApplication CreateApp() => new Core.App();

        protected override MvxLogProviderType GetDefaultLogProviderType() => MvxLogProviderType.None;

        protected override void InitializePlatformServices()
        {
            base.InitializePlatformServices();
            Mvx.RegisterType<IModalScreenService, UwpModalScreenService>();
            Mvx.RegisterType<IShareService, UwpShareService>();
            Mvx.RegisterType<IScheduledNotificationService, UwpScheduledNotificationService>();
        }
    }
}
