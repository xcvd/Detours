namespace Polar.MapleTypes
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct COutPacket
    {
        public bool Loopback;

        public IntPtr BufferPointer;

        public int Length;

        public int Offset;

        public bool Encrypted;
    }
}
