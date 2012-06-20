namespace PacketLoggerToFile.DetouredFunctions
{
    using System;

    using PacketLoggerToFile.Util;

    public class CInPacket
    {
        public static readonly MapleFunctions.CInPacket.DDecode1 Decode1 = DetouredDecode1;

        public static readonly MapleFunctions.CInPacket.DDecode2 Decode2 = DetouredDecode2;

        public static readonly MapleFunctions.CInPacket.DDecode4 Decode4 = DetouredDecode4;

        public static readonly MapleFunctions.CInPacket.DDecodeBuffer DecodeBuffer =
            DetouredDecodeBuffer;

        public static readonly MapleFunctions.CInPacket.DDecodeString DecodeString =
            DetouredDecodeString;

        public static byte DetouredDecode1(IntPtr @this)
        {
            var value =
                (byte)Hooks.Manager["CInPacket::Decode1"].CallOriginal(new object[] { @this });
            Logger.LogByte(value);
            return value;
        }

        public static ushort DetouredDecode2(IntPtr @this)
        {
            var value =
                (ushort)Hooks.Manager["CInPacket::Decode2"].CallOriginal(new object[] { @this });
            Logger.LogUshort(value, true);
            return value;
        }

        public static uint DetouredDecode4(IntPtr @this)
        {
            var value =
                (uint)Hooks.Manager["CInPacket::Decode4"].CallOriginal(new object[] { @this });
            Logger.LogUint(value);
            return value;
        }

        public static void DetouredDecodeBuffer(IntPtr @this, IntPtr bufferPointer, uint size)
        {
            Logger.LogBuffer(bufferPointer, size);
            Hooks.Manager["CInPacket::DecodeBuffer"].CallOriginal(
                new object[] { @this, bufferPointer, size });
        }

        public static IntPtr DetouredDecodeString(IntPtr @this, IntPtr resultPointer)
        {
            var value =
                (IntPtr)
                Hooks.Manager["CInPacket::DecodeString"].CallOriginal(
                    new object[] { @this, resultPointer });
            Logger.LogString(value);
            return value;
        }
    }
}
