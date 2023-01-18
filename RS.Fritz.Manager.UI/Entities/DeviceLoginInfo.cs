namespace RS.Fritz.Manager.UI;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;

internal sealed class DeviceLoginInfo : ObservableRecipient
{
    private ObservableInternetGatewayDevice? internetGatewayDevice;
    private User? user;
    private string? password;
    private bool loginInfoSet;

    public DeviceLoginInfo()
        : base(StrongReferenceMessenger.Default)
    {
        IsActive = true;

        StrongReferenceMessenger.Default.Register<PropertyChangedMessage<ObservableInternetGatewayDevice?>>(this, (r, m) =>
        {
            ((DeviceLoginInfo)r).Receive(m);
        });
        StrongReferenceMessenger.Default.Register<PropertyChangedMessage<string?>>(this, (r, m) =>
        {
            ((DeviceLoginInfo)r).Receive(m);
        });
        StrongReferenceMessenger.Default.Register<PropertyChangedMessage<User?>>(this, (r, m) =>
        {
            ((DeviceLoginInfo)r).Receive(m);
        });
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

    private async void Receive(PropertyChangedMessage<ObservableInternetGatewayDevice?> message)
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
                        await message.NewValue.ApiDevice.InitializeAsync();

                        message.NewValue.Users = message.NewValue.ApiDevice.Users!;
                    }

                    SetLoginInfo();

                    break;
                }
        }
    }

    private void Receive(PropertyChangedMessage<string?> message)
    {
        if (message.Sender != this)
            return;

        switch (message.PropertyName)
        {
            case nameof(Password):
                if (InternetGatewayDevice is not null)
                    InternetGatewayDevice!.ApiDevice.NetworkCredential = new(User?.Name, Password);

                SetLoginInfo();
                break;
        }
    }

    private void Receive(PropertyChangedMessage<User?> message)
    {
        if (message.Sender != this)
            return;

        switch (message.PropertyName)
        {
            case nameof(User):
                if (InternetGatewayDevice is not null)
                    InternetGatewayDevice.ApiDevice.NetworkCredential = new(User?.Name, Password);

                SetLoginInfo();
                break;
        }
    }

    private void SetLoginInfo()
    {
        LoginInfoSet = InternetGatewayDevice is not null && User is not null && !string.IsNullOrWhiteSpace(Password);
    }
}