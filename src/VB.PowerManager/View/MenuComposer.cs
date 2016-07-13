namespace VB.PowerManager.View
{
    using System;
    using System.Windows.Forms;
    using Interfaces;

    public class MenuComposer : IMenuComposer
    {
        private readonly MenuItemsNotifier itemsNotifier = new MenuItemsNotifier();

        private readonly ContextMenu contextMenu = new ContextMenu();

        public void Add(IMenuItemProxy menuItem)
        {
            AddMenuItemToMenu(menuItem);
        }

        public ContextMenu Display()
        {
            contextMenu.MenuItems.Add(new MenuItem("-"));
            contextMenu.MenuItems.Add("Exit", OnExit);

            return contextMenu;
        }

        private void AddMenuItemToMenu(IMenuItemProxy menuItemProxy)
        {
            itemsNotifier.Attach(menuItemProxy);

            contextMenu.MenuItems.Add((MenuItem)menuItemProxy.GetRealObject());
        }

        private void OnExit(object sender, EventArgs e)
        {
            itemsNotifier.Clean();

            Application.Exit();
        }
    }
}