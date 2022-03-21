namespace RS.Fritz.Manager.UI;

using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using RS.Fritz.Manager.API;

internal sealed class WanPppConnectionGetGenericPortMappingEntryViewModel : WanConnectionGetGenericPortMappingEntryViewModel
{
    public WanPppConnectionGetGenericPortMappingEntryViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger)
        : base(deviceLoginInfo, logger)
    {
    }

    protected override async Task DoExecuteDefaultCommandAsync(CancellationToken cancellationToken = default)
    {
        WanConnectionGetGenericPortMappingEntryResponse = await DeviceLoginInfo.InternetGatewayDevice!.ApiDevice.WanPppConnectionGetGenericPortMappingEntryAsync(Index!.Value);
    }
}