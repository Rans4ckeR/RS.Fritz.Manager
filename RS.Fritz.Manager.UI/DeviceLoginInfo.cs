namespace RS.Fritz.Manager.UI
{
    using System.ComponentModel;
    using CommunityToolkit.Mvvm.ComponentModel;
    using CommunityToolkit.Mvvm.Messaging;
    using RS.Fritz.Manager.Domain;

    internal sealed class DeviceLoginInfo : ObservableObject
    {
        private InternetGatewayDevice? device;
        private User? user;
        private string? password;

        public DeviceLoginInfo()
        {
            PropertyChanged += DeviceLoginInfoPropertyChanged;
        }

        public InternetGatewayDevice? Device
        {
            get => device;
            set => _ = SetProperty(ref device, value);
        }

        public string? Password
        {
            get => password;
            set => _ = SetProperty(ref password, value);
        }

        public User? User
        {
            get => user;
            set => _ = SetProperty(ref user, value);
        }

        private void DeviceLoginInfoPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            WeakReferenceMessenger.Default.Send(new DeviceLoginInfoValueChangedMessage(this));
        }
    }
}