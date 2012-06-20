namespace PacketLoggerToFile.Util
{
    using System;
    using System.IO;
    using System.Runtime.InteropServices;

    public class Logger
    {
        private static bool writingIn;

        public static string Directory { get; set; }

        public static StreamWriter File { get; set; }

        public static void LogOutInit()
        {
            writingIn = false;
            File.WriteLine();
            File.Write("[OUT] ");
        }

        public static void LogInInit()
        {
            File.WriteLine();
            File.Write("[IN] ");
        }

        public static void LogByte(byte value)
        {
            File.Write(value.ToString("X2") + " ");
        }

        public static void LogUshort(ushort value, bool isIn)
        {
            if (isIn && !writingIn)
            {
                writingIn = true;
                LogInInit();
            }
         
            File.Write(value.ToString("X4") + " ");
        }

        public static void LogUint(uint value)
        {
            File.Write(value.ToString("X8") + " ");
        }

        public static void LogBuffer(IntPtr bufferPointer, uint size)
        {
            var buffer = new byte[size];
            Marshal.Copy(bufferPointer, buffer, 0, (int)size);
            File.Write(BitConverter.ToString(buffer) + " ");
        }

        public static void LogString(IntPtr stringPointer)
        {
            var str = Marshal.PtrToStringAnsi(stringPointer);
            File.Write("{0}{1}{0} ", '"', str);
        }

        public static void LogFunctionAddress(string name, IntPtr address)
        {
            File.WriteLine(name + ": " + address.ToString("X8"));
        }
    }
}
