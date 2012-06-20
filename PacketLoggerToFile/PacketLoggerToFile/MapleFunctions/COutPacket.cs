namespace PacketLoggerToFile.MapleFunctions
{
    using System;
    using System.Runtime.InteropServices;

    using PacketLoggerToFile.Util;

    public class COutPacket
    {
        public static readonly FunctionInfo[] FunctionInfo = new[]
            {
                new FunctionInfo(
                    "56 8B F1 8B 46 ?? 57 8D 7E ?? 85 C0",
                    0,
                    "COutPacket::Encode1",
                    DetouredFunctions.COutPacket.Encode1,
                    Encode1,
                    typeof(DEncode1)),
                new FunctionInfo(
                    "8B 40 ?? 03 C0 3B C8 77 ?? 8D 4C 24 ?? 51 6A ?? 50 8B CF E8 ?? ?? ?? ?? 8B 56 ?? 8B 07 66 8B 4C 24 ?? 66 89 0C 02",
                    0x21,                    
                    "COutPacket::Encode2",
                    DetouredFunctions.COutPacket.Encode2,
                    Encode2,
                    typeof(DEncode2)),
                new FunctionInfo(
                    "56 8B F1 8B 46 ?? 57 8D 7E ?? 85 C0 74 ?? 8B 40 ?? 8B 4E ?? 83 C1 ??",
                    0,
                    "COutPacket::Encode4",
                    DetouredFunctions.COutPacket.Encode4,
                    Encode4,
                    typeof(DEncode4)),
                new FunctionInfo(
                    "53 56 8B F1 8B 46 ?? 57 8D 7E ?? 85 C0",
                    0,
                    "COutPacket::EncodeBuffer",
                    DetouredFunctions.COutPacket.EncodeBuffer,
                    EncodeBuffer,
                    typeof(DEncodeBuffer)),
                new FunctionInfo(
                    "8B 17 03 56 ?? 8D 44 24 ?? 52 51",
                    0x75,
                    "COutPacket::EncodeString",
                    DetouredFunctions.COutPacket.EncodeString,
                    EncodeString,
                    typeof(DEncodeString)),
                new FunctionInfo(
                    "68 ?? ?? ?? ?? C7 01 ?? ?? ?? ?? E8 ?? ?? ?? ?? 8B 4C 24 ?? 51",
                    0x30,
                    "COutPacket::Init",
                    DetouredFunctions.COutPacket.Init,
                    Init,
                    typeof(DInit))
            };
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void DEncode1(IntPtr @this, [In] byte value);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void DEncode2(IntPtr @this, [In] ushort value);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void DEncode4(IntPtr @this, [In] uint value);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void DEncodeBuffer(IntPtr @this, [In] IntPtr bufferPointer, [In] uint size);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void DEncodeString(IntPtr @this, [In] IntPtr stringPointer);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void DInit(IntPtr @this, [In] int type);

        public static DEncode1 Encode1 { get; set; }

        public static DEncode2 Encode2 { get; set; }

        public static DEncode4 Encode4 { get; set; }

        public static DEncodeBuffer EncodeBuffer { get; set; }

        public static DEncodeString EncodeString { get; set; }

        public static DInit Init { get; set; }
    }
}
