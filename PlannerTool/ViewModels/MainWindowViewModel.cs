using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Notifications;

//https://www.thomasclaudiushuber.com/2019/04/26/calling-windows-10-apis-from-your-wpf-application/

namespace PlannerTool.ViewModels
{
    class MainWindowViewModel : NotifyPropertyChanged
    {
        public Command CommandProp { get; set; }

        public MainWindowViewModel()
        {
            CommandProp = new Command(Commands, CanExecute);
        }

        public void Commands(object wnd)
        {

            var content = new ToastContentBuilder()
                        .AddText("Andrew sent you a picture")
                        .AddText("Check this out, Happy Canyon in Utah!")
                        .GetToastContent();

            // Create the notification
            var notif = new ToastNotification(content.GetXml());

            // And then show it
            ToastNotificationManager.CreateToastNotifier().Show(notif);

        }

        public bool CanExecute(object wnd)
        {
            return true;
        }
    }
}
