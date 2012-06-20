namespace PacketLoggerToFile.MapleFunctions
{
    using System;
    using System.Runtime.InteropServices;

    using PacketLoggerToFile.Util;

    public class CSocket
    {        
        public static readonly FunctionInfo[] FunctionInfo = new[]
        {
            new FunctionInfo(
                "8B D9 8B 2D ?? ?? ?? ?? 89 6C 24 ?? 85 ED 74 ?? 8D 45 ?? 50",
                0x27,
                "CSocket::ProcessPacket",
                DetouredFunctions.CClientSocket.SendPacket,
                ProcessPacket,
                typeof(DProcessPacket))
        };

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate int DProcessPacket(IntPtr @this, IntPtr packetPointer);

        public static DProcessPacket ProcessPacket { get; set; }
    }
}
