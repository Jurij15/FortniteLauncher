using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace FortniteLauncher.Cores
{
    public class InjectSSLbypass
    {
        public static void InjectDll(int processId, string path)
        {
            IntPtr hProcess = Win32.OpenProcess(1082, false, processId);
            IntPtr procAddress = Win32.GetProcAddress(Win32.GetModuleHandle("kernel32.dll"), "LoadLibraryA");
            uint num = (uint)((path.Length + 1) * Marshal.SizeOf(typeof(char)));
            IntPtr intPtr = Win32.VirtualAllocEx(hProcess, IntPtr.Zero, num, 12288U, 4U);
            UIntPtr uintPtr;
            Win32.WriteProcessMemory(hProcess, intPtr, Encoding.Default.GetBytes(path), num, out uintPtr);
            Win32.CreateRemoteThread(hProcess, IntPtr.Zero, 0U, procAddress, intPtr, 0U, IntPtr.Zero);
        }
    }
}
