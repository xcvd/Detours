namespace PacketLoggerToFile.Util
{
    using System.Runtime.InteropServices;

    using PacketLoggerToFile.MapleFunctions;

    public static class Hooks
    {
        private static readonly Detours.HookManager manager = new Detours.HookManager();

        public static Detours.HookManager Manager
        {
            get
            {
                return manager;
            }
        }

        public static void FindFunctions()
        {
            FunctionInfo.MapleStoryFunctions.AddRange(COutPacket.FunctionInfo);                    
            
            // FunctionInfo.MapleStoryFunctions.AddRange(CClientSocket.FunctionInfo);
            // FunctionInfo.MapleStoryFunctions.AddRange(CInPacket.FunctionInfo);
            // FunctionInfo.MapleStoryFunctions.AddRange(CSocket.FunctionInfo);
            foreach (var function in FunctionInfo.MapleStoryFunctions)
            {
                function.SetTarget(
                    Marshal.GetDelegateForFunctionPointer(
                        Scanner.FindPattern(function.Pattern, function.Offset), function.TargetType));
                Logger.LogFunctionAddress(
                    function.Name, Marshal.GetFunctionPointerForDelegate(function.Target));
            }
        }

        public static void Set()
        {
            foreach (var function in FunctionInfo.MapleStoryFunctions)
            {
                manager.Add(function.Target, function.Detour, function.Name);                
            }

            manager.InstallAll();
        }
    }
}

