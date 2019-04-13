using System;
using Windows.UI.Popups;
using Zadania.Core.Services;

namespace Zadania.Uwp.Services
{
    public class UwpModalScreenService : IModalScreenService
    {
        public void ConfirmAdditionalAction(string title, string content, Action confirmAction, Action cancelAction)
        {
            var yesCommand = new UICommand("Tak", cmd => { confirmAction(); });
            var noCommand = new UICommand("Nie", cmd => { cancelAction(); });
            var dialog = new MessageDialog(content, title);
            dialog.Options = MessageDialogOptions.None;

            dialog.Commands.Add(yesCommand);
            dialog.DefaultCommandIndex = 0;
            dialog.CancelCommandIndex = 0;
            dialog.Commands.Add(noCommand);
            dialog.CancelCommandIndex = (uint)dialog.Commands.Count - 1;

            dialog.ShowAsync();
        }
    }
}
