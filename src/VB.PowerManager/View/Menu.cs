namespace VB.PowerManager.View
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using Properties;

    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();

            var systemTrayMenu = CreateSystemTrayMenu();

            var notifyIcon = CreateNotifyIcon();

            SetIconAndShow(notifyIcon, systemTrayMenu);
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

            return notifyIcon;
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
