namespace RS.Fritz.Manager.UI;

using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;
using Microsoft.Extensions.Logging;
using RS.Fritz.Manager.API;

internal sealed class WanPppConnectionViewModel : FritzServiceViewModel, IRecipient<PropertyChangedMessage<WanAccessType?>>
{
    private WanPppConnectionGetInfoResponse? wanPppConnectionGetInfoResponse;

    public WanPppConnectionViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger)
        : base(deviceLoginInfo, logger)
    {
    }

    public WanPppConnectionGetInfoResponse? WanPppConnectionGetInfoResponse
    {
        get => wanPppConnectionGetInfoResponse;
        private set { _ = SetProperty(ref wanPppConnectionGetInfoResponse, value); }
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

    protected override async Task DoExecuteDefaultCommandAsync()
    {
        WanPppConnectionGetInfoResponse = await DeviceLoginInfo.InternetGatewayDevice!.ExecuteAsync((h, d) => h.WanPppConnectionGetInfoAsync(d));
    }

    protected override bool GetCanExecuteDefaultCommand()
    {
        return base.GetCanExecuteDefaultCommand() && DeviceLoginInfo.InternetGatewayDevice!.WanAccessType == WanAccessType.Dsl;
    }
}