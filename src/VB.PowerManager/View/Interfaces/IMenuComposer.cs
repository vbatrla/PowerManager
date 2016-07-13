namespace VB.PowerManager.View.Interfaces
{
    using System.Windows.Forms;

    public interface IMenuComposer
    {
        void Add(IMenuItemProxy menuItem);

        ContextMenu Display();
    }
}