namespace VB.PowerManager.View
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using Interfaces;

    public class MenuItemsNotifier 
    {
        public List<IMenuItem> MenuItems = new List<IMenuItem>();

        public void Attach(IMenuItem menuItem)
        {
            MenuItems.Add(menuItem);

            menuItem.PropertyChanged += MenuItemOnPropertyChanged;
        }

        public void Detach(IMenuItem menuItem)
        {
            MenuItems.Remove(menuItem);

            menuItem.PropertyChanged -= MenuItemOnPropertyChanged;
        }

        public void Notify(int hash)
        {
            foreach (var menuItem in MenuItems.Where(m => m.Hash != hash))
            {
                menuItem.Update();
            }
        }

        public void Clean()
        {
            foreach (var menuItem in MenuItems.ToList())
            {
                Detach(menuItem);
            }
        }

        private void MenuItemOnPropertyChanged(
            object sender, 
            PropertyChangedEventArgs propertyChangedEventArgs)
        {
            var menuItem = (IMenuItem) sender;

            this.Notify(menuItem.Hash);
        }
    }
}