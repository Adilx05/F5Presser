using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace Deneme
{

    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public int Z = 900000;
        public int S = 5;

        public void ButtonF_OnClick(object sender, RoutedEventArgs routedEventArgs)
        {
            System.Timers.Timer t = new System.Timers.Timer(Z);
            if (TextBlock.Text == "Deactive")
            {
            S = 6;
            TextBlock.Text = "Active";
            t.Elapsed += new ElapsedEventHandler(Yenileme);
            t.Start();
            }
            else
            {
                S = 5;
                t.Stop();
                TextBlock.Text = "Deactive";
                this.ShowMessageAsync("","Stopped");
            }

            if (ButtonF.Content.ToString() == "Press F5")
            {
                ButtonF.Content = "Stop";
            }
            else
            {
                ButtonF.Content = "Press F5";
            }

        }

        [DllImport("user32.dll")]
        public static extern int FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll")]
        public static extern int SetForegroundWindow(int hWnd);

        public void Yenileme(object o, ElapsedEventArgs a)
        {
            if (S == 6)
            {
                int hwnd = FindWindow(null, "League Of Legends");
                SetForegroundWindow(hwnd);
                SendKeys.SendWait("{F5}");
            }
        }

        private void ListBoxItem1_OnSelected(object sender, RoutedEventArgs e)
        {
            Z = 900000;
        }
        private void ListBoxItem2_OnSelected(object sender, RoutedEventArgs e)
        {
            Z = 1800000;
        }
        private void ListBoxItem3_OnSelected(object sender, RoutedEventArgs e)
        {
            Z = 2700000;
        }
        private void ListBoxItem4_OnSelected(object sender, RoutedEventArgs e)
        {
            Z = 3600000;
        }
    }
}
