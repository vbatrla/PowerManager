namespace VB.PowerManager.Tests
{
    using NUnit.Framework;
    using VB.PowerManager.AppCore.Enums;

    [TestFixture]
    public class PowerManagerTests
    {
        [Test]
        public void GetActiveScheme_Balanced_Returned()
        {
            PowerManager.SetActiveScheme(PerformanceEnum.Balanced);

            var scheme = PowerManager.GetActiveScheme();

            Assert.That(scheme, Is.EqualTo(PerformanceEnum.Balanced));            
        }

        [Test]
        public void GetActiveScheme_High_Returned()
        {
            PowerManager.SetActiveScheme(PerformanceEnum.High);

            var scheme = PowerManager.GetActiveScheme();

            Assert.That(scheme, Is.EqualTo(PerformanceEnum.High));
        }

        [Test]
        public void GetActiveScheme_Saver_Returned()
        {
            PowerManager.SetActiveScheme(PerformanceEnum.Saver);

            var scheme = PowerManager.GetActiveScheme();

            Assert.That(scheme, Is.EqualTo(PerformanceEnum.Saver));
        }
    }
}
