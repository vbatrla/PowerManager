namespace VB.PowerManager.View
{
    using System;
    using System.Drawing;
    using System.Reflection;
    using System.Windows.Forms;
    using Properties;

    public partial class Menu : Form
    {
        private NotifyIcon notifyIcon;

        public Menu()
        {
            InitializeComponent();

            var systemTrayMenu = CreateSystemTrayMenu();

            notifyIcon = CreateNotifyIcon();

            SetIconAndShow(notifyIcon, systemTrayMenu);
        }

        private void NotifyIconMouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button.Equals(MouseButtons.Left))
            {
                var showContextMenu = typeof(NotifyIcon).GetMethod(
                    "ShowContextMenu", 
                    BindingFlags.Instance | BindingFlags.NonPublic);
                showContextMenu.Invoke(notifyIcon, null);
            }
        }

        private void SetIconAndShow(NotifyIcon notifyIcon, ContextMenu sysTrayMenu)
        {
            notifyIcon.ContextMenu = sysTrayMenu;
            notifyIcon.Visible = true;
        }

        private NotifyIcon CreateNotifyIcon()
        {
            var notifyIcon = new NotifyIcon
            {
                Text = Settings.Default.AppName,
                Icon = new Icon(Resources.Lightning, 48, 48)
            };

            notifyIcon.MouseUp += NotifyIconMouseUp;

            return notifyIcon;
        }

        protected override void OnClosed(EventArgs e)
        {
            notifyIcon.MouseUp -= NotifyIconMouseUp;
        }

        private ContextMenu CreateSystemTrayMenu()
        {
            var facade = new MenuFacade(new MenuComposer());

            return facade.ComposeMenu();
        }

        protected override void OnLoad(EventArgs e)
        {
            Visible = false;
            ShowInTaskbar = false;

            base.OnLoad(e);
        }
    }
}
