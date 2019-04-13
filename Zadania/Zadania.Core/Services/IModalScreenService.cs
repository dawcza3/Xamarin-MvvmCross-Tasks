using System;

namespace Zadania.Core.Services
{
    public interface IModalScreenService
    {
        void ConfirmAdditionalAction(string title, string content, 
            Action confirmAction, Action cancelAction);
    }
}
