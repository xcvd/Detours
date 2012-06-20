namespace PacketLoggerToFile.MapleFunctions
{
    using System;
    using System.Runtime.InteropServices;

    using Util;

    public class CClientSocket
    {
        public static readonly FunctionInfo[] FunctionInfo = new[]
            {
                new FunctionInfo(
                    "1D ?? ?? ?? ?? 56 EB ?? 00 00 86 36",
                    0x58,
                    "CClientSocket::SendPacket",
                    DetouredFunctions.CClientSocket.SendPacket,
                    SendPacket,
                    typeof(DSendPacket))
            };                 

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate int DSendPacket(IntPtr @this, IntPtr packetPointer);

        public static DSendPacket SendPacket { get; set; }  
    }
}
