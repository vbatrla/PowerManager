namespace VB.PowerManager.Tests.View
{
    using System;
    using NSubstitute;
    using NUnit.Framework;
    using VB.PowerManager.AppCore.Enums;
    using VB.PowerManager.View;
    using VB.PowerManager.View.Interfaces;

    [TestFixture]
    public class MenuFacadeTests
    {
        [Test]
        public void ComposeMenu_AddThreeItemsToMenu_WillBeAdded()
        {
            this.Facade.ComposeMenu();
            this.Composer.Received(3).Add(Arg.Any<IMenuItemProxy>());
        }

        [TestCase(PerformanceEnum.High)]
        [TestCase(PerformanceEnum.Balanced)]
        [TestCase(PerformanceEnum.Saver)]
        public void CreateMenuItem_WithDefaultValues_WillHave(PerformanceEnum performance)
        {
            var item = this.Facade.CreateMenuItem(performance);
           
            Assert.That(item.Checked, Is.EqualTo(PowerManager.GetActiveScheme().Equals(performance)));
            Assert.IsTrue(item.RadioCheck);
        }

        [SetUp]
        public void SetupEach()
        {
            this.Composer = Substitute.For<IMenuComposer>();
            this.Facade = new MenuFacade(this.Composer);
        }

        public IMenuComposer Composer { get; set; }

        public MenuFacade Facade { get; set; }
    }
}