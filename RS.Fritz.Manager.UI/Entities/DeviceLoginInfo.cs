namespace RS.Fritz.Manager.UI
{
    using System.Net;
    using CommunityToolkit.Mvvm.ComponentModel;
    using CommunityToolkit.Mvvm.Messaging;
    using CommunityToolkit.Mvvm.Messaging.Messages;
    using RS.Fritz.Manager.API;

    internal sealed class DeviceLoginInfo : ObservableRecipient, IRecipient<PropertyChangedMessage<ObservableInternetGatewayDevice?>>, IRecipient<PropertyChangedMessage<string?>>, IRecipient<PropertyChangedMessage<User?>>
    {
        private ObservableInternetGatewayDevice? internetGatewayDevice;
        private User? user;
        private string? password;
        private bool loginInfoSet;

        public DeviceLoginInfo()
        {
            IsActive = true;
        }

        public ObservableInternetGatewayDevice? InternetGatewayDevice
        {
            get => internetGatewayDevice;
            set => _ = SetProperty(ref internetGatewayDevice, value, true);
        }

        public string? Password
        {
            get => password;
            set => _ = SetProperty(ref password, value, true);
        }

        public User? User
        {
            get => user;
            set => _ = SetProperty(ref user, value, true);
        }

        public bool LoginInfoSet
        {
            get => loginInfoSet;
            private set => _ = SetProperty(ref loginInfoSet, value, true);
        }

        public async void Receive(PropertyChangedMessage<ObservableInternetGatewayDevice?> message)
        {
            if (message.Sender != this)
                return;

            switch (message.PropertyName)
            {
                case nameof(InternetGatewayDevice):
                    {
                        if (message.NewValue is null)
                        {
                            User = null;
                            Password = null;
                        }
                        else
                        {
                            await message.NewValue.InternetGatewayDevice.InitializeAsync();

                            message.NewValue.Users = message.NewValue.InternetGatewayDevice.Users!;
                        }

                        SetLoginInfo();

                        break;
                    }
            }
        }

        public void Receive(PropertyChangedMessage<string?> message)
        {
            if (message.Sender != this)
                return;

            switch (message.PropertyName)
            {
                case nameof(Password):
                    InternetGatewayDevice!.InternetGatewayDevice.NetworkCredential = new NetworkCredential(User?.Name, Password);

                    SetLoginInfo();
                    break;
            }
        }

        public void Receive(PropertyChangedMessage<User?> message)
        {
            if (message.Sender != this)
                return;

            switch (message.PropertyName)
            {
                case nameof(User):
                    InternetGatewayDevice!.InternetGatewayDevice.NetworkCredential = new NetworkCredential(User?.Name, Password);

                    SetLoginInfo();
                    break;
            }
        }

        private void SetLoginInfo()
        {
            LoginInfoSet = InternetGatewayDevice is not null && User is not null && !string.IsNullOrWhiteSpace(Password);
        }
    }
}