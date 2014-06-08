using System;
using System.Runtime.InteropServices;

namespace Ego
{
    public enum EnumWindowState
    {
        Normal = 1,
        Maximized = 3,
        Minimized = 6,
        Restore = 9
    }// WindowState
    public static class snippets
    {
        #region imports
        [DllImport("user32.dll")]
        static extern int GetWindowThreadProcessId(IntPtr hWnd, IntPtr ProcessId);
        [DllImport("kernel32.dll")]
        private static extern int GetCurrentThreadId();
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll")]
        static extern bool AttachThreadInput(int idAttach, int idAttachTo, bool fAttach);
        [DllImport("user32.dll")]
        static extern bool BringWindowToTop(IntPtr hWnd);
        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        #endregion

        //[ref] http://www.xtremevbtalk.com/showthread.php?t=318187
        public static void SetForegroundWindow(IntPtr hWnd)
        {
            int ThreadID1 = GetWindowThreadProcessId(GetForegroundWindow(), (IntPtr)0);
            int ThreadID2 = GetCurrentThreadId();
            // By sharing input state, threads share their concept of the active window.
            if (ThreadID1 != ThreadID2)
            {
                AttachThreadInput(ThreadID1, ThreadID2, true);
                BringWindowToTop(hWnd);
                ShowWindow(hWnd, (int)EnumWindowState.Normal);
                AttachThreadInput(ThreadID1, ThreadID2, false);
            }//if
            else
            {
                BringWindowToTop(hWnd);
                ShowWindow(hWnd, (int)EnumWindowState.Normal);
            }//else
        }//SetForegroundWindow
    }//class
}//namepsace