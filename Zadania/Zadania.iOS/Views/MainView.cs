using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using MvvmCross.iOS.Views.Presenters.Attributes;

namespace Zadania.iOS.Views
{
    [MvxRootPresentation(WrapInNavigationController = true)]
    public partial class MainView : MvxViewController
    {
        public MainView() : base("MainView", null)
        {

        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var set = this.CreateBindingSet<MainView, Core.ViewModels.MainViewModel>();
            set.Bind(datePicker).For(x => x.Date).To(vm => vm.Date);
            set.Bind(timePicker).For(x => x.Date)
                .To(vm => vm.Time)
                                .WithConversion("Time");
            set.Bind(workText).To(x => x.Work);
            set.Bind(addWorkButton).To(x => x.AddWorkCommand);
            set.Apply();
        }
    }
}
