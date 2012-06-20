namespace PacketLoggerToFile
{
    using System;
    using System.IO;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using System.Threading;

    using PacketLoggerToFile.Util;

    using RGiesecke.DllExport;

    internal static class UnmanagedExports
    {
        [DllExport("EntryPoint")]
        public static void DllMain(IntPtr messagePointer)
        {
            var message = (Message)Marshal.PtrToStructure(messagePointer, typeof(Message));
            Logger.Directory = message.Directory;
            Logger.File = new StreamWriter(Logger.Directory + "\\log.txt")
                {
                    AutoFlush = true 
                };
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomainAssemblyResolve;
            new Thread(
                () =>
                    {
                        Hooks.FindFunctions();
                        Hooks.Set();
                    }).Start();
        }

        public static Assembly CurrentDomainAssemblyResolve(object sender, ResolveEventArgs args)
        {            
            return args.Name.StartsWith("Detours")
                       ? Assembly.LoadFile(Logger.Directory + "\\Detours.dll")
                       : sender as Assembly;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct Message
        {
            [MarshalAs(UnmanagedType.LPWStr)]
            public string Directory;
        }
    }
}
