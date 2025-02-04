﻿using System.Collections.Frozen;
using System.Security;
using System.ServiceModel.Security;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;

namespace RS.Fritz.Manager.UI;

internal sealed class DeviceLoginInfo : ObservableRecipient
{
    private const string DslWanAccessType = "DSL";

    private static readonly FrozenSet<string> EthernetWanAccessTypes = ["Ethernet", "X_AVM-DE_Fiber", "X_AVM-DE_UMTS", "X_AVM-DE_Cable", "X_AVM-DE_LTE"];

    private readonly ILogger logger;

    public DeviceLoginInfo(ILogger<DeviceLoginInfo> logger)
        : base(StrongReferenceMessenger.Default)
    {
        IsActive = true;
        this.logger = logger;

        StrongReferenceMessenger.Default.Register<PropertyChangedMessage<ObservableInternetGatewayDevice?>>(this, static (r, m) => ((DeviceLoginInfo)r).Receive(m));
        StrongReferenceMessenger.Default.Register<PropertyChangedMessage<InternetGatewayDevice?>>(this, static (r, m) => ((DeviceLoginInfo)r).Receive(m));
        StrongReferenceMessenger.Default.Register<PropertyChangedMessage<SecureString?>>(this, static (r, m) => ((DeviceLoginInfo)r).Receive(m));
        StrongReferenceMessenger.Default.Register<PropertyChangedMessage<User?>>(this, static (r, m) => ((DeviceLoginInfo)r).Receive(m));
    }

    public ObservableInternetGatewayDevice? InternetGatewayDevice
    {
        get;
        set => _ = SetProperty(ref field, value, true);
    }

    public InternetGatewayDevice? SelectedInternetGatewayDevice
    {
        get;
        set => _ = SetProperty(ref field, value, true);
    }

    public SecureString? Password
    {
        get;
        set => _ = SetProperty(ref field, value, true);
    }

    public User? User
    {
        get;
        set => _ = SetProperty(ref field, value, true);
    }

    public bool LoginInfoSet
    {
        get;
        private set => _ = SetProperty(ref field, value, true);
    }

    public bool Authenticated
    {
        get;
        private set => _ = SetProperty(ref field, value, true);
    }

    public WanAccessType? WanAccessType
    {
        get;
        set => _ = SetProperty(ref field, value, true);
    }

#pragma warning disable SA1500 // Braces for multi-line statements should not share line
#pragma warning disable SA1513 // Closing brace should be followed by blank line
    public IEnumerable<User> Users
    {
        get;
        private set => _ = SetProperty(ref field, value, true);
    } = [];
#pragma warning restore SA1500 // Braces for multi-line statements should not share line
#pragma warning restore SA1513 // Closing brace should be followed by blank line

    public async ValueTask GetDeviceTypeAsync()
    {
        WanCommonInterfaceConfigGetCommonLinkPropertiesResponse wanCommonInterfaceConfigGetCommonLinkProperties;

        try
        {
            wanCommonInterfaceConfigGetCommonLinkProperties = await SelectedInternetGatewayDevice!.WanCommonInterfaceConfigGetCommonLinkPropertiesAsync().ConfigureAwait(true);
        }
        catch (MessageSecurityException)
        {
            Authenticated = false;

            throw;
        }

        Authenticated = true;
        WanAccessType = wanCommonInterfaceConfigGetCommonLinkProperties.WanAccessType switch
        {
            DslWanAccessType => UI.WanAccessType.Dsl,
            { } q when EthernetWanAccessTypes.Contains(q) => UI.WanAccessType.Ethernet,
            _ => throw new ArgumentOutOfRangeException(nameof(WanCommonInterfaceConfigGetCommonLinkPropertiesResponse.WanAccessType), wanCommonInterfaceConfigGetCommonLinkProperties.WanAccessType, null)
        };
    }

    // ReSharper disable once AsyncVoidMethod
    private async void Receive(PropertyChangedMessage<ObservableInternetGatewayDevice?> message)
    {
        try
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
                            SelectedInternetGatewayDevice = null;
                        }
                        else
                        {
                            SelectedInternetGatewayDevice = message.NewValue.InternetGatewayDevices.FirstOrDefault(static q => q.IsAvm) ?? message.NewValue.InternetGatewayDevices.MaxBy(static q => q.Version);

                            await SelectedInternetGatewayDevice!.InitializeAsync().ConfigureAwait(true);

                            Users = SelectedInternetGatewayDevice.Users!;
                            User = Users.SingleOrDefault(static q => q.LastUser);
                        }

                        SetLoginInfo();

                        break;
                    }
            }
        }
        catch (Exception ex)
        {
            logger.ExceptionThrown(ex);
        }
    }

    private void Receive(PropertyChangedMessage<InternetGatewayDevice?> message)
    {
        if (message.Sender != this)
            return;

        switch (message.PropertyName)
        {
            case nameof(SelectedInternetGatewayDevice):
                {
                    Authenticated = false;

                    SetLoginInfo();

                    break;
                }
        }
    }

    private void Receive(PropertyChangedMessage<SecureString?> message)
    {
        if (message.Sender != this)
            return;

        switch (message.PropertyName)
        {
            case nameof(Password):
                if (SelectedInternetGatewayDevice is not null)
                    SelectedInternetGatewayDevice.NetworkCredential = new(User?.Name, Password);

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
                if (SelectedInternetGatewayDevice is not null)
                    SelectedInternetGatewayDevice.NetworkCredential = new(User?.Name, Password);

                SetLoginInfo();
                break;
        }
    }

    private void SetLoginInfo()
        => LoginInfoSet = SelectedInternetGatewayDevice is not null && User is not null && Password is not null;
}