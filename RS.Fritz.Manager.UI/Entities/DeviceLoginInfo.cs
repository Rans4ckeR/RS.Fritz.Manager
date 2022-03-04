namespace RS.Fritz.Manager.UI
{
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Xml;
    using System.Xml.Serialization;
    using CommunityToolkit.Mvvm.ComponentModel;
    using CommunityToolkit.Mvvm.Messaging;
    using CommunityToolkit.Mvvm.Messaging.Messages;
    using RS.Fritz.Manager.API;

    internal sealed class DeviceLoginInfo : ObservableRecipient, IRecipient<PropertyChangedMessage<ObservableInternetGatewayDevice?>>, IRecipient<PropertyChangedMessage<string?>>, IRecipient<PropertyChangedMessage<User?>>
    {
        private readonly IFritzServiceOperationHandler fritzServiceOperationHandler;

        private ObservableInternetGatewayDevice? internetGatewayDevice;
        private User? user;
        private string? password;
        private bool loginInfoSet;

        public DeviceLoginInfo(IFritzServiceOperationHandler fritzServiceOperationHandler)
        {
            this.fritzServiceOperationHandler = fritzServiceOperationHandler;
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
                            fritzServiceOperationHandler.InternetGatewayDevice = null;
                            User = null;
                            Password = null;
                        }
                        else
                        {
                            fritzServiceOperationHandler.InternetGatewayDevice = message.NewValue.InternetGatewayDevice;

                            DeviceInfoGetSecurityPortResponse deviceInfoGetSecurityPortResponse = await fritzServiceOperationHandler.DeviceInfoGetSecurityPortAsync();

                            message.NewValue.InternetGatewayDevice.SecurityPort = deviceInfoGetSecurityPortResponse.SecurityPort;

                            LanConfigSecurityGetUserListResponse lanConfigSecurityGetUserListResponse = await fritzServiceOperationHandler.LanConfigSecurityGetUserListAsync();

                            using var stringReader = new StringReader(lanConfigSecurityGetUserListResponse.UserList);
                            using var xmlTextReader = new XmlTextReader(stringReader);

                            UserList? userList = (UserList?)new XmlSerializer(typeof(UserList)).Deserialize(xmlTextReader);

                            message.NewValue.Users = userList?.Users ?? Enumerable.Empty<User>();
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
                    fritzServiceOperationHandler.NetworkCredential = new NetworkCredential(User?.Name, Password);

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
                    fritzServiceOperationHandler.NetworkCredential = new NetworkCredential(User?.Name, Password);

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