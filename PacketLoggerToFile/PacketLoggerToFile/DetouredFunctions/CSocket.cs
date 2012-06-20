namespace PacketLoggerToFile.DetouredFunctions
{
    using System;

    using PacketLoggerToFile.Util;

    public class CSocket
    {
        public static readonly MapleFunctions.CSocket.DProcessPacket ProcessPacket = DetouredProcessPacket;

        public static int DetouredProcessPacket(IntPtr @this, IntPtr packetPointer)
        {
            Logger.LogInInit();
            return
                (int)
                Hooks.Manager["CSocket::ProcessPacket"].CallOriginal(
                    new object[] { @this, packetPointer });
        }
    }
}
