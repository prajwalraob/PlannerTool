using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Notifications;
using PlannerTool.Model;

//https://adamtheautomator.com/how-to-set-up-and-manage-scheduled-tasks-with-powershell/#Deleting_a_Scheduled_Task
//https://www.c-sharpcorner.com/article/setup-task-scheduler-to-run-application/
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

        private DateTime _startDate;
        public DateTime StartDate
        {
            get => _startDate;
            set
            {
                _startDate = value;
                OnPropertyChanged();
            }
        }

        private DateTime _endDate;
        public DateTime EndDate
        {
            get => _endDate;
            set
            {
                _endDate = value;
                OnPropertyChanged();
            }
        }

        private DateTime _selectedDate;
        public DateTime SelectedDate
        {
            get => _selectedDate;
            set
            {
                _selectedDate = value;
                OnPropertyChanged();
            }
        }

        private int? _hours;
        public int? Hours
        {
            get => _hours;
            set
            {
                _hours = value;
                OnPropertyChanged();
            }
        }

        private int? _minutes;
        public int? Minutes
        {
            get => _minutes;
            set
            {
                _minutes = value;
                OnPropertyChanged();
            }
        }

        public MainWindowViewModel()
        {
            CommandProp = new Command(Commands, CanExecute);
            RunCommandProp = new Command(RunCommand);
            SelectedDate = DateTime.Today;
            StartDate = DateTime.MinValue;
            EndDate = DateTime.Today.AddDays(-1);
            Minutes = 0;
            Hours = 0;
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
            ReadTask read = new ReadTask(Title, Body, SelectedDate, Hours.Value, Minutes.Value);
        }
    }
}
