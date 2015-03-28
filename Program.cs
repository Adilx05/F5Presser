using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;

namespace F5Basıcı
{
    class Program
    {
        static void Main(string[] args)
              {
      System.Timers.Timer t = new System.Timers.Timer(900 * 1000);
      t.Elapsed += new ElapsedEventHandler(Yenileme);
      t.Elapsed += new ElapsedEventHandler(Yaz);
      t.Elapsed += new ElapsedEventHandler(Zaman);
      t.Start();

      while(true)
      {
      
      }
                }

         static void Yenileme(object o, ElapsedEventArgs a)
   {
     int hwnd = FindWindow(null, "League Of Legends");
            SetForegroundWindow(hwnd);
            SendKeys.SendWait("{F5}");
   }
        static void Yaz(object o, ElapsedEventArgs a)
         {
             Console.WriteLine("Last Press Time");
         }
        static void Zaman(object o, ElapsedEventArgs a)
        {
            Console.WriteLine(DateTime.Now);
        }
        [DllImport("user32.dll")]
        public static extern int FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll")]
        public static extern int SetForegroundWindow(int hWnd);
    }
}
