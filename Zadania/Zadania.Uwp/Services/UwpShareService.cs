using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.ApplicationModel.DataTransfer;
using Windows.Foundation;
using Windows.Storage;
using Windows.Storage.Streams;
using Zadania.Core.Services;

namespace Zadania.Uwp.Services
{
    public class UwpShareService : IShareService
    {
        private string _content;

        public void Share(string content)
        {
            _content = content;
            RegisterForShare();
            DataTransferManager.ShowShareUI();
        }

        private void RegisterForShare()
        {
            DataTransferManager dataTransferManager = DataTransferManager.GetForCurrentView();
            dataTransferManager.DataRequested += new TypedEventHandler<DataTransferManager, DataRequestedEventArgs>(this.ShareImageHandler);
        }

        private async void ShareImageHandler(DataTransferManager sender, DataRequestedEventArgs e)
        {
            DataRequest request = e.Request;
            request.Data.Properties.Title = "Aplikacja Zadania";
            request.Data.Properties.Description = "Podziel się swoim zadaniem z innymi!";
            request.Data.SetText($"Zadanie dodane dnia {DateTime.Now}\n{_content}");

            DataRequestDeferral deferral = request.GetDeferral();
            deferral.Complete();

        }
    }
}
