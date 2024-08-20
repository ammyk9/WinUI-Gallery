using System;
using System.Runtime.InteropServices;
using static WinUIGallery.App;

namespace WinUIGallery
{
    internal static partial class Win32
    {
        [LibraryImport("user32.dll")]
        public static partial IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, IntPtr lParam);

        [LibraryImport("user32.dll", StringMarshalling = StringMarshalling.Utf16)]
        public static partial IntPtr LoadIconW(IntPtr hInstance, string lpIconName);

        [LibraryImport("user32.dll")]
        public static partial IntPtr GetActiveWindow();

        [LibraryImport("kernel32.dll", StringMarshalling = StringMarshalling.Utf16)]
        public static partial IntPtr GetModuleHandleW(string moduleName);

        [LibraryImport("User32.dll")]
        internal static partial int GetDpiForWindow(IntPtr hwnd);

        [LibraryImport("user32.dll", EntryPoint = "SetWindowLongW")]
        internal static partial int SetWindowLong32(IntPtr hWnd, WindowLongIndexFlags nIndex, WinProc newProc);

        [LibraryImport("user32.dll", EntryPoint = "SetWindowLongPtrW")]
        internal static partial IntPtr SetWindowLongPtr64(IntPtr hWnd, WindowLongIndexFlags nIndex, WinProc newProc);

        [LibraryImport("user32.dll", EntryPoint = "CallWindowProcW")]
        internal static partial IntPtr CallWindowProc(IntPtr lpPrevWndFunc, IntPtr hWnd, WindowMessage Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        private static extern uint GetCurrentThreadId();

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        private static extern int SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hInstance, int threadId);

        [DllImport("User32.dll", SetLastError = true, CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int CallNextHookEx(int idHook, int nCode, IntPtr wParam, IntPtr lParam);


        public static int SetWindowKeyHook(HookProc hookProc)
        {
            return SetWindowsHookEx(WH_KEYBOARD, hookProc, GetModuleHandle(IntPtr.Zero), (int)GetCurrentThreadId());
        }

        public static bool IsKeyDownHook(IntPtr lWord)
        {
            // The 30th bit tells what the previous key state is with 0 being the "UP" state
            // For more info see https://learn.microsoft.com/windows/win32/winmsg/keyboardproc#lparam-in
            return (lWord >> 30 & 1) == 0;
        }

        public const int WM_ACTIVATE = 0x0006;
        public const int WA_ACTIVE = 0x01;
        public const int WA_INACTIVE = 0x00;
        public const int WH_KEYBOARD = 2;
        public const int WM_KEYDOWN = 0x0104;

        public const int WM_SETICON = 0x0080;
        public const int ICON_SMALL = 0;
        public const int ICON_BIG = 1;

        internal delegate IntPtr WinProc(IntPtr hWnd, WindowMessage Msg, IntPtr wParam, IntPtr lParam);
        public delegate int HookProc(int nCode, IntPtr wParam, IntPtr lParam);

        [Flags]
        internal enum WindowLongIndexFlags : int
        {
            GWL_WNDPROC = -4,
        }

        internal enum WindowMessage : int
        {
            WM_GETMINMAXINFO = 0x0024,
        }
    }
}
