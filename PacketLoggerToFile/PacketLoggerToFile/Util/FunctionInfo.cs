namespace PacketLoggerToFile.Util
{
    using System;
    using System.Collections.Generic;

    public class FunctionInfo
    {
        public static readonly List<FunctionInfo> MapleStoryFunctions = new List<FunctionInfo>();

        public readonly string Pattern;

        public readonly int Offset;

        public readonly string Name;

        public readonly Delegate Detour;
        
        public readonly Type TargetType;

        public FunctionInfo(string pattern, int offset, string name, Delegate detour, Delegate target, Type targetType)
        {
            this.Pattern = pattern;
            this.Offset = offset;
            this.Name = name;
            this.Detour = detour;
            this.Target = target;
            this.TargetType = targetType;
        }

        public Delegate Target { get; set; }

        public void SetTarget(Delegate target)
        {
            this.Target = target;
        }
    }
}