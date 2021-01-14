using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PlannerTool.Models;

namespace Notifier
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static DependencyProperty TitleStringProperty = DependencyProperty.Register("TitleString", typeof(string), typeof(MainWindow), new PropertyMetadata());
        public string TitleString
        {
            get { return (string)GetValue(TitleStringProperty); }
            set { this.SetValue(TitleStringProperty, value); }
        }

        public static DependencyProperty BodyStringProperty = DependencyProperty.Register("BodyString", typeof(string), typeof(MainWindow), new PropertyMetadata());
        public string BodyString
        {
            get { return (string)GetValue(BodyStringProperty); }
            set { this.SetValue(BodyStringProperty, value); }
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        public void SetMessage(TaskItem taskObj)
        {
            TitleString = taskObj.Title;
            BodyString = taskObj.Body;
        }

        public void CloseMethod(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
