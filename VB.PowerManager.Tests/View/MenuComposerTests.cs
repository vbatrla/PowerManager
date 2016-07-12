namespace VB.PowerManager.Tests.View
{
    using NUnit.Framework;
    using VB.PowerManager.View;

    [TestFixture]
    public class MenuComposerTests
    {
        [Test]
        public void Display_Default_HasTwoItems()
        {
            var composer = new MenuComposer();

            var menu = composer.Display();

            Assert.AreEqual(2, menu.MenuItems.Count);
        }    
    }
}