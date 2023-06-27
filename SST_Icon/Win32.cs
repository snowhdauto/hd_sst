using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace SST_Icon
{
    internal static class Win32
    {
        /// <summary>
        /// Дескриптор окна, которому отправляется сообщение. Данное значение отсылает сообщение всем окнам.
        /// </summary>
        public static readonly IntPtr HWND_BROADCAST = new IntPtr(0xFFFF);

        /// <summary>
        /// Код сообщения для активации главного окна.
        /// </summary>
        public static readonly uint WM_MAINFORM_ACTIVATE = RegisterWindowMessage("WM_MAINFORM_ACTIVATE");

        /// <summary>
        /// Добавляет значение в очередь сообщений указанного окна.
        /// </summary>
        /// <param name="hwnd">Дескриптор окна, в очередь сообщений которого будет добавлено сообщение.</param>
        /// <param name="msg">Код сообщения.</param>
        /// <param name="wparam">Дополнительный параметр.</param>
        /// <param name="lparam">Дополнительный параметр.</param>
        /// <returns>True, если сообщение добавлено успешно.</returns>
        [DllImport("user32")]
        public static extern bool PostMessage(IntPtr hwnd, int msg, IntPtr wparam, IntPtr lparam);

        /// <summary>
        /// Регистрирует в системе новое сообщение.
        /// </summary>
        /// <param name="message">Имя сообщения.</param>
        /// <returns>Код зарегистрированного сообщения</returns>
        [DllImport("user32")]
        public static extern uint RegisterWindowMessage(string message);
    }
}
