using System;
using System.Runtime.InteropServices;

namespace SampleWapper
{
    public class Wapper
    {
        [DllImport(@"CppImport\Demo.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Add(int a, int b);
    }
}
