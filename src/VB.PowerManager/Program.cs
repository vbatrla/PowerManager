namespace VB.PowerManager
{
    using System;
    using System.Windows.Forms;
    using Menu = View.Menu;

    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Menu());
        }
    }
}
