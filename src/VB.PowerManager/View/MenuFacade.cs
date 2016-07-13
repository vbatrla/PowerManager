namespace VB.PowerManager.View
{
    using System.Windows.Forms;
    using AppCore.Enums;
    using AppCore.Helpers;
    using Interfaces;

    public class MenuFacade
    {
        private readonly IMenuComposer composer;

        public MenuFacade(IMenuComposer composer)
        {
            this.composer = composer;
        }

        public ContextMenu ComposeMenu()
        {
            composer.Add(CreateMenuItem(PerformanceEnum.High));
            composer.Add(CreateMenuItem(PerformanceEnum.Balanced));
            composer.Add(CreateMenuItem(PerformanceEnum.Saver));
            return composer.Display();
        }

        public IMenuItemProxy CreateMenuItem(PerformanceEnum performance)
        {
            var menuItem = new MenuItemProxy(
                performance.GetName(), 
                () => { PowerManager.SetActiveScheme(performance); });

            menuItem.RadioCheck = true;
            menuItem.Checked = performance.Equals(PowerManager.GetActiveScheme());

            return menuItem;
        }
    }
}