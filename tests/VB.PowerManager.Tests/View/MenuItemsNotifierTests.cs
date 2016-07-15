namespace VB.PowerManager.Tests.View
{
    using System.ComponentModel;
    using NSubstitute;
    using NUnit.Framework;
    using VB.PowerManager.View;
    using VB.PowerManager.View.Interfaces;

    [TestFixture]
    public class MenuItemsNotifierTests
    {
        public MenuItemsNotifier Notifier = new MenuItemsNotifier();

        [Test]
        public void Attach_IsSubscribed()
        {
            var menuItem = Substitute.For<IMenuItem>();

            Notifier.Attach(menuItem);

            Assert.That(Notifier.MenuItems, Has.Member(menuItem));
        }

        [Test]
        public void Detach_Unsubscribed()
        {
            var menuItem = Substitute.For<IMenuItem>();

            Notifier.Attach(menuItem);

            Notifier.Detach(menuItem);

            Assert.That(Notifier.MenuItems, Has.No.Member(menuItem));
        }

        [Test]
        [NUnit.Framework.Category("Integration")]
        public void Notify_JustNotifyOthers_Notified()
        {
            var notifier = new MenuItemsNotifier();

            var firstItem = new MenuItemProxy("A", (() => { }));
            var secondItem = new MenuItemProxy("B", (() => { }));
            // Prop which must be changed to false
            secondItem.Checked = true;

            notifier.Attach(firstItem);
            notifier.Attach(secondItem);

            // Notify others
            firstItem.PerformClick();

            Assert.IsFalse(secondItem.Checked);
        }

        [SetUp]
        public void SetupEach()
        {
            
        }
    }
}
