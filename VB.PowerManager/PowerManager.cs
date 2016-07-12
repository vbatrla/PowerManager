namespace VB.PowerManager
{
    using System;
    using System.Runtime.InteropServices;
    using AppCore.Enums;
    using AppCore.Helpers;

    public class PowerManager
    {
        private static ulong Success = 0;

        [DllImport("powrprof.dll", EntryPoint = "PowerSetActiveScheme")]
        public static extern uint PowerSetActiveScheme(IntPtr UserPowerKey, ref Guid ActivePolicyGuid);

        [DllImport("powrprof.dll", EntryPoint = "PowerGetActiveScheme")]
        public static extern uint PowerGetActiveScheme(IntPtr UserPowerKey, out IntPtr ActivePolicyGuid);

        public static void SetActiveScheme(PerformanceEnum performance)
        {
            var plan = performance.GetGuid();

            PowerSetActiveScheme(IntPtr.Zero, ref plan);
        }

        public static PerformanceEnum GetActiveScheme()
        {
            IntPtr ptr;
            var result = PowerGetActiveScheme(IntPtr.Zero, out ptr);

            if (result == Success)
            {
                var guid = Marshal.PtrToStructure(ptr, typeof(Guid));

                return EnumHelper.GetEnumValueByGuid<PerformanceEnum>((Guid)guid);
            }

            throw new Exception();
        }
    }
}