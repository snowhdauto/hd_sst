using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;


namespace SST_Icon
{
    static class Program
    {
        // Имя мьютекса
        static readonly string MutexName = "SST_Icon";

        // Промежуток времени, в течение которого подождать возможного закрытия уже работающей копии приложения.
        static readonly TimeSpan Timeout = TimeSpan.FromMilliseconds(200);

        [STAThread]
        static void Main()
        {
            bool isFirstInstance;
            using (var mutex = new Mutex(true, MutexName, out isFirstInstance))
            {
                // Мьютекс только что создан (первый запуск) или другая копия закрылась в течение установленного промежутка времени.
                if (isFirstInstance || mutex.WaitOne(Timeout))
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);

                    try { Application.Run(new MainForm()); }
                    finally { mutex.ReleaseMutex(); }
                }
                else ActivateRunningInstance(); // Уже работает другая копия — отправить ей сообщение на активацию.
            }
        }

        static void ActivateRunningInstance()
        {
            Win32.PostMessage(Win32.HWND_BROADCAST, (int)Win32.WM_MAINFORM_ACTIVATE, IntPtr.Zero, IntPtr.Zero);
        }
    }
}
