using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Framey.Input
{
    internal class Native
    {
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool GetCursorPos(ref POINT pt);

        [StructLayout(LayoutKind.Sequential)]
        internal struct POINT
        {
            public Int32 X;
            public Int32 Y;
        };
    }
}
