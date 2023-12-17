using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace XIVAutoKey.Libs
{
    internal class Common
    {
        [DllImport("user32.dll")]
        private static extern IntPtr PostMessage(IntPtr hwnd, uint Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        /// <summary>
        /// 发送按键信息
        /// </summary>
        /// <param name="key"></param>
        public static void SendHotkey(IntPtr hWnd, Char key)
        {
            if (key == '无') return;

            const uint WM_KEYDOWN = 0x0100;
            const uint WM_KEYUP = 0x0101;
            PostMessage(hWnd, WM_KEYDOWN, (IntPtr)key, 0);
            Thread.Sleep(3);
            PostMessage(hWnd, WM_KEYUP, (IntPtr)key, 0);
        }

        public static IntPtr GetHwnd()
        {
            return FindWindow(null, "最终幻想XIV");
        }
    }
}
