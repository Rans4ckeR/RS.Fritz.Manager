﻿namespace RS.Fritz.Manager.UI;

using System.Threading;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;
using Microsoft.Extensions.Logging;
using RS.Fritz.Manager.API;

internal sealed class WanIpConnectionViewModel : FritzServiceViewModel, IRecipient<PropertyChangedMessage<WanAccessType?>>
{
    private WanIpConnectionGetInfoResponse? wanIpConnectionGetInfoResponse;

    public WanIpConnectionViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger)
        : base(deviceLoginInfo, logger)
    {
    }

    public WanIpConnectionGetInfoResponse? WanIpConnectionGetInfoResponse
    {
        get => wanIpConnectionGetInfoResponse;
        private set { _ = SetProperty(ref wanIpConnectionGetInfoResponse, value); }
    }

    public void Receive(PropertyChangedMessage<WanAccessType?> message)
    {
        if (message.Sender != DeviceLoginInfo.InternetGatewayDevice)
            return;

        switch (message.PropertyName)
        {
            case nameof(ObservableInternetGatewayDevice.WanAccessType):
                {
                    UpdateCanExecuteDefaultCommand();
                    break;
                }
        }
    }

    protected override async Task DoExecuteDefaultCommandAsync(CancellationToken cancellationToken = default)
    {
        WanIpConnectionGetInfoResponse = await DeviceLoginInfo.InternetGatewayDevice!.ApiDevice.WanIpConnectionGetInfoAsync();
    }

    protected override bool GetCanExecuteDefaultCommand()
    {
        return base.GetCanExecuteDefaultCommand() && DeviceLoginInfo.InternetGatewayDevice!.WanAccessType == WanAccessType.Ethernet;
    }
}