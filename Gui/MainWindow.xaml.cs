using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Media;
using Ionic.Zip;
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
            Process[] pname = Process.GetProcessesByName("leagueoflegends");
            Process[] spname = Process.GetProcessesByName("league of legends");

            if (pname.Length == 0)
            {
                if (spname.Length == 0)
                {
                    this.ShowMessageAsync("Error", "Lol Not Running");
                }
                else
                {
                    System.Timers.Timer t = new System.Timers.Timer(Z);
                    if (TextBlock.Text == "Deactive")
                    {
                        S = 6;
                        TextBlock.Text = "Active";
                        TextBlock.Foreground = Brushes.Green;
                        t.Elapsed += new ElapsedEventHandler(Yenileme);
                        t.Start();
                    }
                    else
                    {
                        S = 5;
                        t.Stop();
                        TextBlock.Text = "Deactive";
                        TextBlock.Foreground = Brushes.Red;
                        this.ShowMessageAsync("", "Stopped");
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
                
            }
            else
            {

                System.Timers.Timer t = new System.Timers.Timer(Z);
                if (TextBlock.Text == "Deactive")
                {
                    S = 6;
                    TextBlock.Text = "Active";
                    TextBlock.Foreground = Brushes.Green;
                    t.Elapsed += new ElapsedEventHandler(Yenileme);
                    t.Start();
                }
                else
                {
                    S = 5;
                    t.Stop();
                    TextBlock.Text = "Deactive";
                    TextBlock.Foreground = Brushes.Red;
                    this.ShowMessageAsync("", "Stopped");
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


        }
       

        [DllImport("user32.dll")]
        public static extern int FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll")]
        public static extern int SetForegroundWindow(int hWnd);

        public void Yenileme(object o, ElapsedEventArgs a)
        {
            if (S == 6)
            {
              /*  int hwnd = FindWindow(null, "League Of Legends");
                SetForegroundWindow(hwnd);
                SendKeys.SendWait("{F5}");*/
                Process p = Process.GetProcessesByName("leagueoflegends").FirstOrDefault();
                if (p != null)
                {
                    int h = (int) p.MainWindowHandle;
                    SetForegroundWindow(h);
                    SendKeys.SendWait("{F5}");
                }

                Process p2 = Process.GetProcessesByName("league of legends").FirstOrDefault();
                if (p2 != null)
                {
                    int h = (int)p2.MainWindowHandle;
                    SetForegroundWindow(h);
                    SendKeys.SendWait("{F5}");
                }
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

        private void ListBoxItem5_OnSelected(object sender, RoutedEventArgs e)
        {
            Z = 300000;
        }

        private void ListBoxItem6_OnSelected(object sender, RoutedEventArgs e)
        {
            Z = 600000;
        }
        private void ListBoxItem_OnSelected(object sender, RoutedEventArgs e)
        {
            Z = 60000;
        }
        private void ComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.ShowMessageAsync("Info", "Interval Has Been Changed");
        }


        private async void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            Process sil = new Process();
            sil.StartInfo.FileName = "cmd.exe";
            sil.StartInfo.Arguments = "/C RMDIR \"Temp\" /S /Q ";
            sil.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            sil.Start();

            Process sil2 = new Process();
            sil2.StartInfo.FileName = "cmd.exe";
            sil2.StartInfo.Arguments = "/C DEL F5.zip /S /Q";
            sil2.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            sil2.Start();

            var wc = new WebClient { Proxy = null };
#region Güncelleme
            try
            {
                var guncelleme = wc.DownloadString("https://raw.githubusercontent.com/Adilx05/F5Presser/master/version.txt");
                if (guncelleme != "100")
                {
                    using (var client = new WebClient())
                    {
                        var controller = await this.ShowProgressAsync("Please Wait", "Updating");
                        client.DownloadFile(
                            "https://raw.githubusercontent.com/Adilx05/F5Presser/master/Gui/F5.zip",
                            "F5.zip");
                        client.DownloadFileCompleted += Client_DownloadFileCompleted;
                        string cikarilacak = "F5.zip";
                        using (ZipFile zip1 = ZipFile.Read(cikarilacak))
                        {
                            foreach (ZipEntry s in zip1)
                            {
                                s.Extract("Temp", ExtractExistingFileAction.OverwriteSilently);
                            }
                        }
                        await controller.CloseAsync();
                    }
                    await this.ShowMessageAsync("Info", "Update completed. Please restart.");
                }

            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("Info", "Please check your internet connection.");
            }
#endregion Güncelleme
        }
        private void Client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            //Gereksiz
        }

        private void MainWindow_OnClosed(object sender, EventArgs e)
        {
            Process tasi = new Process();

            tasi.StartInfo.FileName = "cmd.exe";
            tasi.StartInfo.Arguments = "/C XCOPY Temp\\* /y";
            tasi.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            tasi.Start();
        }
    }
}
