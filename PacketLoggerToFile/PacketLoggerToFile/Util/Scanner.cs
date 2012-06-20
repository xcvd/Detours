namespace PacketLoggerToFile.Util
{
    using System;
    using System.Runtime.InteropServices;

    public class Scanner
    {                
        private const int Size = 0xFFFFFF;

        private static IntPtr handle = GetModuleHandle(null);

        private static byte[] buffer;

        public static byte[] Buffer
        {
            get
            {
                if (buffer == null)
                {
                    try
                    {
                        buffer = new byte[Size];
                        Marshal.Copy(handle, buffer, 0, Size);
                    }
                    catch
                    {
                        buffer = null;
                    }
                }

                return buffer;
            }
        }

        [DllImport("kernel32.dll")]
        public static extern IntPtr GetModuleHandle(string moduleName);

        public static IntPtr FindPattern(string pattern, int offset)
        {
            try
            {
                pattern = pattern.Replace("-", string.Empty);
                pattern = pattern.Replace(" ", string.Empty);

                if (buffer == null || buffer.Length == 0)
                {
                    buffer = new byte[Size];
                    Marshal.Copy(handle, buffer, 0, Size);
                }

                if (pattern.Length % 2 != 0)
                {
                    return (IntPtr)(-1);
                }

                for (var i = 0; i < buffer.Length - (pattern.Length / 2); i++)
                {
                    if (MaskCheck(i, pattern))
                    {
                        return new IntPtr(handle.ToInt32() + (i - offset));
                    }
                }

                return (IntPtr)(-2);
            }
            catch
            {
                return (IntPtr)(-3);
            }
        }

        private static bool MaskCheck(int offset, string pattern)
        {
            for (var i = 0; i < pattern.Length / 2; i++)
            {
                var val = pattern.Substring(i * 2, 2);
                if (val == "??")
                {
                    continue;
                }

                var value = Convert.ToInt32(val, 16);
                if (value != buffer[offset + i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
