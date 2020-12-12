using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Notifications;

namespace PlannerTool.ViewModels
{
    class MainWindowViewModel : NotifyPropertyChanged
    {
        public Command CommandProp { get; set; }
        public Command RunCommandProp { get; set; }

        private string _title;
        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged();
            }
        }

        private string _body;
        public string Body
        {
            get => _body;
            set
            {
                _body = value;
                OnPropertyChanged();
            }
        }

        public MainWindowViewModel()
        {
            CommandProp = new Command(Commands, CanExecute);
            RunCommandProp = new Command(RunCommand);
        }

        public void Commands(object wnd)
        {

            var content = new ToastContentBuilder()
                        .AddText("Andrew sent you a picture")
                        .AddText("Check this out, Happy Canyon in Utah!")
                        .GetToastContent();

            // Create the notification
            var notif = new ScheduledToastNotification(content.GetXml(), DateTime.Now.AddSeconds(30));
            //https://www.thomasclaudiushuber.com/2019/04/26/calling-windows-10-apis-from-your-wpf-application/
            //https://docs.microsoft.com/en-us/windows/uwp/design/shell/tiles-and-notifications/scheduled-toast
            // And then show it
            ToastNotificationManager.CreateToastNotifier().AddToSchedule(notif);

        }

        public bool CanExecute(object wnd)
        {
            return true;
        }

        public void RunCommand(object wnd)
        {

        }
    }
}
