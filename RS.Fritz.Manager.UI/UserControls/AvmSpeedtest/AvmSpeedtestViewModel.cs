namespace RS.Fritz.Manager.UI;

using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using RS.Fritz.Manager.API;

internal sealed class AvmSpeedtestViewModel : FritzServiceViewModel
{
    private AvmSpeedtestGetInfoResponse? avmSpeedtestGetInfoResponse;

    public AvmSpeedtestViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger)
        : base(deviceLoginInfo, logger)
    {
    }

    public AvmSpeedtestGetInfoResponse? AvmSpeedtestGetInfoResponse
    {
        get => avmSpeedtestGetInfoResponse;
        private set { _ = SetProperty(ref avmSpeedtestGetInfoResponse, value); }
    }

    protected override async Task DoExecuteDefaultCommandAsync(CancellationToken cancellationToken = default)
    {
        AvmSpeedtestGetInfoResponse = await DeviceLoginInfo.InternetGatewayDevice!.ApiDevice.AvmSpeedtestGetInfoAsync();
    }
}