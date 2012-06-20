namespace PacketLoggerToFile.DetouredFunctions
{
    using System;

    using PacketLoggerToFile.Util;

    public class CClientSocket
    {
        public static readonly MapleFunctions.CClientSocket.DSendPacket SendPacket = DetouredSendPacket;

        public static int DetouredSendPacket(IntPtr @this, IntPtr packetPointer)
        {
            return
                (int)
                Hooks.Manager["CClientSocket::SendPacket"].CallOriginal(
                    new object[] { @this, packetPointer });            
        }
    }
}
