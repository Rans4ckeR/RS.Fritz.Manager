namespace RS.Fritz.Manager.UI
{
    using System.ComponentModel;
    using CommunityToolkit.Mvvm.ComponentModel;
    using CommunityToolkit.Mvvm.Messaging;
    using RS.Fritz.Manager.Domain;

    internal sealed class DeviceLoginInfo : ObservableObject
    {
        private InternetGatewayDevice? internetGatewayDevice;
        private User? user;
        private string? password;

        public DeviceLoginInfo()
        {
            PropertyChanged += DeviceLoginInfoPropertyChanged;
        }

        public InternetGatewayDevice? InternetGatewayDevice
        {
            get => internetGatewayDevice;
            set => _ = SetProperty(ref internetGatewayDevice, value);
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