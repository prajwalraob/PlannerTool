using System;
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

namespace PlannerTool.Views
{
    /// <summary>
    /// Interaction logic for TimeSetter.xaml
    /// </summary>
    public partial class TimeSetter : UserControl
    {
        public string Hours
        {
            get { return (string)GetValue(HoursProperty); }
            set { SetValue(HoursProperty, value); }
        }

        public static readonly DependencyProperty HoursProperty =
            DependencyProperty.Register("Hours", typeof(string),
                typeof(TimeSetter), new PropertyMetadata());

        public string Minutes
        {
            get { return (string)GetValue(MinutesProperty); }
            set { SetValue(MinutesProperty, value); }
        }

        public static readonly DependencyProperty MinutesProperty =
            DependencyProperty.Register("Minutes", typeof(string),
                typeof(TimeSetter), new PropertyMetadata());

        //public string Seconds
        //{
        //    get { return (string)GetValue(SecondsProperty); }
        //    set { SetValue(SecondsProperty, value); }
        //}

        //public static readonly DependencyProperty SecondsProperty =
        //    DependencyProperty.Register("Seconds", typeof(string),
        //        typeof(TimeSetter), new PropertyMetadata());


        public TimeSetter()
        {
            InitializeComponent();

        }

        private void TextBox_PreviewTextInputHour(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsValidHour(((TextBox)sender).Text + e.Text);
        }

        private void TextBox_PreviewTextInputMinSec(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsValidMinSec(((TextBox)sender).Text + e.Text);
        }

        public static bool IsValidHour(string str)
        {
            int i;
            return int.TryParse(str, out i) && i >= 0 && i <= 23;
        }
        public static bool IsValidMinSec(string str)
        {
            int i;
            return int.TryParse(str, out i) && i >= 0 && i <= 59;
        }
    }
}
