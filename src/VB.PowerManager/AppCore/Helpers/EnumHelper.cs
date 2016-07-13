namespace VB.PowerManager.AppCore.Helpers
{
    using System;
    using System.Linq;
    using Attributes;
    using Enums;

    public static class EnumHelper
    {
        public static Guid GetGuid(this Enum value)
        {
            var type = value.GetType();
            var name = Enum.GetName(type, value);

            return type.GetField(name)
                .GetCustomAttributes(false)
                .OfType<GuidEnumAttribute>()
                .First()
                .Guid;
        }

        public static string GetName(this Enum value)
        {
            var type = value.GetType();
            var name = Enum.GetName(type, value);

            return type.GetField(name)
                .GetCustomAttributes(false)
                .OfType<NameAttribute>()
                .First()
                .Name;
        }

        public static T GetEnumValueByGuid<T>(Guid guid)
        {
            var memberInfo = typeof(T)
                .GetMembers()
                .First(m => m.GetCustomAttributes(false)
                    .OfType<GuidEnumAttribute>()
                    .Any(g => g.Guid.Equals(guid)));

            return (T)Enum.Parse(typeof(T), memberInfo.Name);
        }
    }
}