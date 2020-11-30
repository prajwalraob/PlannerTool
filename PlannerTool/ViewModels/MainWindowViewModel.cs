using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        }

        public bool CanExecute(object wnd)
        {
            return false;
        }
    }
}
