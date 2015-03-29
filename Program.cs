using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using System.Threading;

namespace F5Basıcı
{
    class Program
    {
        static void Main(string[] args)
              {
      System.Timers.Timer t = new System.Timers.Timer(900000);
      t.Elapsed += new ElapsedEventHandler(Yenileme);
      t.Elapsed += new ElapsedEventHandler(Yaz);
      t.Elapsed += new ElapsedEventHandler(Zaman);
      t.Start();

      while(true)
      { // 1 Saniyelik Uyku
          Thread.Sleep(1000);
      }
                }

         static void Yenileme(object o, ElapsedEventArgs a)
   { // Gönderilen Tuş
     int hwnd = FindWindow(null, "League Of Legends");
            SetForegroundWindow(hwnd);
            SendKeys.SendWait("{F5}");
   }
        static void Yaz(object o, ElapsedEventArgs a)
         {// Son Gönderilme Zamanı
             Console.WriteLine("Son Gönderme Zamanı");
         }
        static void Zaman(object o, ElapsedEventArgs a)
        {// Son Gönderilme Tarihi
            Console.WriteLine(DateTime.Now);
        }
        [DllImport("user32.dll")]
        public static extern int FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll")]
        public static extern int SetForegroundWindow(int hWnd);
    }
}
