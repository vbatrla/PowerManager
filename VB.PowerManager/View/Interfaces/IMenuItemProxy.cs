namespace VB.PowerManager.View.Interfaces
{
    using System;

    public interface IMenuItemProxy : IMenuItem
    {
        bool Checked { get; set; }

        bool RadioCheck { get; set; }

        event EventHandler Click;

        object GetRealObject();

        void PerformClick();
    }
}