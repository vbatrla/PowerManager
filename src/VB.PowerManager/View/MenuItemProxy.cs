namespace VB.PowerManager.View
{
    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;
    using Annotations;
    using Interfaces;

    public sealed class MenuItemProxy : IMenuItemProxy
    {
        private readonly MenuItem menuItem;

        private readonly Action action;

        public MenuItemProxy(string name, Action action)
        {
            this.menuItem = new MenuItem(name);
            Click += OnClick;

            this.action = action;

            this.Hash = this.GetHashCode();
        }

        public int Hash { get; set; }

        public event EventHandler Click
        {
            add
            {
                menuItem.Click += value;
            }
            remove
            {
                menuItem.Click -= value;
            }
        }

        public object GetRealObject()
        {
            return menuItem;
        }

        public void PerformClick()
        {
            menuItem.PerformClick();
        }

        public bool Checked
        {
            get
            {
                return menuItem.Checked;
            }

            set
            {
                menuItem.Checked = value;
            }
        }

        public bool RadioCheck
        {
            get
            {
                return menuItem.RadioCheck;
            }

            set
            {
                menuItem.RadioCheck = value;
            }
        }

        public void Update()
        {
            Checked = false;
        }

        public void Dispose()
        {
            Click -= OnClick;
        }

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void OnClick(object sender, EventArgs eventArgs)
        {
            action.Invoke();

            Checked = true;

            OnPropertyChanged();
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}