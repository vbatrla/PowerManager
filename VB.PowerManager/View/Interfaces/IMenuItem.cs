namespace VB.PowerManager.View.Interfaces
{
    using System.ComponentModel;

    public interface IMenuItem : INotifyPropertyChanged
    {
        int Hash { get; set; }

        void Update();
    }
}