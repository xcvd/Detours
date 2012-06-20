namespace PacketLoggerToFile.MapleFunctions
{
    using System;
    using System.Runtime.InteropServices;

    using PacketLoggerToFile.Util;

    public class CInPacket
    {
        public static readonly FunctionInfo[] FunctionInfo = new[]
            {
                new FunctionInfo(
                    "F8 01 73",
                    0x42,
                    "CInPacket::Decode1",
                    DetouredFunctions.CInPacket.Decode1,
                    Decode1,
                    typeof(DDecode1)),
                new FunctionInfo(
                    "F8 02 73",
                    0x42,
                    "CInPacket::Decode2",
                    DetouredFunctions.CInPacket.Decode2,
                    Decode2,
                    typeof(DDecode2)),
                new FunctionInfo(
                    "F8 04 ?? 3F 68 ?? ?? ?? ?? 8D 45 ?? 50",
                    0x42,
                    "CInPacket::Decode4",
                    DetouredFunctions.CInPacket.Decode4,
                    Decode4,
                    typeof(DDecode4)),
                new FunctionInfo(
                    "B7 ?? 0C ?? 4E 14 ?? 56",
                    0x31,
                    "CInPacket::DecodeBuffer",
                    DetouredFunctions.CInPacket.DecodeBuffer,
                    DecodeBuffer,
                    typeof(DDecodeBuffer)),
                new FunctionInfo(
                    "0F B7 56 ?? 8B 4E ?? 89 45 ?? 8B 46 ?? 2B D0",
                    0x48,
                    "CInPacket::DecodeString",
                    DetouredFunctions.CInPacket.DecodeString,
                    DecodeString,
                    typeof(DDecodeString))
            };

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate byte DDecode1(IntPtr @this);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate ushort DDecode2(IntPtr @this);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate uint DDecode4(IntPtr @this);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void DDecodeBuffer(IntPtr @this, IntPtr bufferPointer, uint size);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate IntPtr DDecodeString(IntPtr @this, IntPtr resultPointer);

        public static DDecode1 Decode1 { get; set; }

        public static DDecode2 Decode2 { get; set; }

        public static DDecode4 Decode4 { get; set; }

        public static DDecodeBuffer DecodeBuffer { get; set; }

        public static DDecodeString DecodeString { get; set; }
    }
}
