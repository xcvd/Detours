namespace PacketLoggerToFile.DetouredFunctions
{
    using System;

    using PacketLoggerToFile.Util;

    public class COutPacket
    {
        public static readonly MapleFunctions.COutPacket.DEncode1 Encode1 = DetouredEncode1;

        public static readonly MapleFunctions.COutPacket.DEncode2 Encode2 = DetouredEncode2;

        public static readonly MapleFunctions.COutPacket.DEncode4 Encode4 = DetouredEncode4;

        public static readonly MapleFunctions.COutPacket.DEncodeBuffer EncodeBuffer =
            DetouredEncodeBuffer;

        public static readonly MapleFunctions.COutPacket.DEncodeString EncodeString =
            DetouredEncodeString;

        public static readonly MapleFunctions.COutPacket.DInit Init = DetouredInit;

        public static void DetouredEncode1(IntPtr @this, byte value)
        {
            Logger.LogByte(value);
            Hooks.Manager["COutPacket::Encode1"].CallOriginal(new object[] { @this, value });            
        }

        public static void DetouredEncode2(IntPtr @this, ushort value)
        {
            Logger.LogUshort(value, true);
            Hooks.Manager["COutPacket::Encode2"].CallOriginal(new object[] { @this, value });            
        }

        public static void DetouredEncode4(IntPtr @this, uint value)
        {
            Logger.LogUint(value);
            Hooks.Manager["COutPacket::Encode4"].CallOriginal(new object[] { @this, value });            
        }

        public static void DetouredEncodeBuffer(IntPtr @this, IntPtr buffer, uint size)
        {            
            Hooks.Manager["COutPacket::EncodeBuffer"].CallOriginal(new object[] { @this, buffer, size });
            Logger.LogBuffer(buffer, size);
        }

        public static void DetouredEncodeString(IntPtr @this, IntPtr stringPointer)
        {
            Logger.LogString(stringPointer);
            Hooks.Manager["COutPacket::EncodeString"].CallOriginal(new object[] { @this, stringPointer });            
        }

        public static void DetouredInit(IntPtr @this, int type)
        {
            Logger.LogOutInit();
            Hooks.Manager["COutPacket::Init"].CallOriginal(new object[] { @this, type });            
        }
    }
}
