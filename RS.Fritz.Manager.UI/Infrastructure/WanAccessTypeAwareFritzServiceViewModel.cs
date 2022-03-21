namespace RS.Fritz.Manager.UI;

using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;
using Microsoft.Extensions.Logging;

internal abstract class WanAccessTypeAwareFritzServiceViewModel : FritzServiceViewModel, IRecipient<PropertyChangedMessage<WanAccessType?>>
{
    private readonly WanAccessType wanAccessType;

    protected WanAccessTypeAwareFritzServiceViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger, WanAccessType wanAccessType)
        : base(deviceLoginInfo, logger)
    {
        this.wanAccessType = wanAccessType;
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

    protected override bool GetCanExecuteDefaultCommand()
    {
        return base.GetCanExecuteDefaultCommand() && DeviceLoginInfo.InternetGatewayDevice!.WanAccessType == wanAccessType;
    }
}