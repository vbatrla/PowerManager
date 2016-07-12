namespace VB.PowerManager.AppCore.Enums
{
    using Attributes;

    public enum PerformanceEnum
    {
        [Name("High performance")]
        [GuidEnum("8c5e7fda-e8bf-4a96-9a85-a6e23a8c635c")]
        High,

        [Name("Power saver")]
        [GuidEnum("a1841308-3541-4fab-bc81-f71556f20b4a")]
        Saver,

        [Name("Balanced")]
        [GuidEnum("381b4222-f694-41f0-9685-ff5bb260df2e")]
        Balanced
    }
}