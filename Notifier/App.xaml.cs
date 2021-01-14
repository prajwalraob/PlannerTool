using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;
using PlannerTool.Models;

namespace Notifier
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            MainWindow wnd = new MainWindow();
            string jsonString = e.Args[0].Replace("\\u022","\"");
            TaskItem task = JsonConvert.DeserializeObject(jsonString, typeof(TaskItem)) as TaskItem;
            wnd.SetMessage(task);
            wnd.ShowDialog();
        }
    }
}
