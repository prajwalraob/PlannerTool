using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PlannerTool
{
    [ClassInterface(ClassInterfaceType.None)]
    [ComSourceInterfaces(typeof(INotificationActivationCallback))]
    [Guid("8D232C9D-F86E-4788-AD52-1027108C616F"), ComVisible(true)]
    class WindowsServiceCreator : NotificationActivator
    {
        public WindowsServiceCreator()
        {

        }

        public override void OnActivated(string arguments, NotificationUserInput userInput, string appUserModelId)
        {
            throw new NotImplementedException();
        }
    }
}
