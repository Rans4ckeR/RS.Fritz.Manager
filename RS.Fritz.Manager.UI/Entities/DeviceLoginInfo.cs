namespace RS.Fritz.Manager.UI
{
    using System.Net;
    using CommunityToolkit.Mvvm.ComponentModel;
    using CommunityToolkit.Mvvm.Messaging;
    using CommunityToolkit.Mvvm.Messaging.Messages;
    using RS.Fritz.Manager.Domain;

    internal sealed class DeviceLoginInfo : ObservableRecipient, IRecipient<PropertyChangedMessage<DeviceLoginInfo>>
    {
        private readonly IFritzServiceOperationHandler fritzServiceOperationHandler;

        private ObservableInternetGatewayDevice? internetGatewayDevice;
        private User? user;
        private string? password;

        public DeviceLoginInfo(IFritzServiceOperationHandler fritzServiceOperationHandler)
        {
            this.fritzServiceOperationHandler = fritzServiceOperationHandler;
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

        public void Receive(PropertyChangedMessage<DeviceLoginInfo> message)
        {
            if (message.NewValue is null)
            {
                fritzServiceOperationHandler.NetworkCredential = null;

                return;
            }

            switch (message.PropertyName)
            {
                case nameof(User):
                case nameof(Password):
                    {
                        fritzServiceOperationHandler.NetworkCredential = new NetworkCredential(User?.Name, Password);
                        break;
                    }
            }
        }
    }
}