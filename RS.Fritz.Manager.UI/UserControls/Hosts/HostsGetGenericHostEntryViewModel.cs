namespace RS.Fritz.Manager.UI;

using System.ComponentModel;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using RS.Fritz.Manager.API;

internal sealed class HostsGetGenericHostEntryViewModel : FritzServiceViewModel
{
    private ushort? index;
    private ushort? hostNumberOfEntries;
    private HostsGetGenericHostEntryResponse? hostsGetGenericHostEntryResponse;

    public HostsGetGenericHostEntryViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger)
        : base(deviceLoginInfo, logger)
    {
    }

    public ushort? Index
    {
        get => index;
        set
        {
            if (SetProperty(ref index, value))
                DefaultCommand.NotifyCanExecuteChanged();
        }
    }

    public ushort? HostNumberOfEntries
    {
        get => hostNumberOfEntries;
        set
        {
            if (SetProperty(ref hostNumberOfEntries, value))
                DefaultCommand.NotifyCanExecuteChanged();
        }
    }

    public HostsGetGenericHostEntryResponse? HostsGetGenericHostEntryResponse
    {
        get => hostsGetGenericHostEntryResponse;
        private set { _ = SetProperty(ref hostsGetGenericHostEntryResponse, value); }
    }

    protected override async Task DoExecuteDefaultCommandAsync()
    {
        HostsGetGenericHostEntryResponse = await DeviceLoginInfo.InternetGatewayDevice!.ExecuteAsync((h, d) => h.HostsGetGenericHostEntryAsync(d, Index!.Value));
    }

    protected override void FritzServiceViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        base.FritzServiceViewModelPropertyChanged(sender, e);

        switch (e.PropertyName)
        {
            case nameof(Index):
                {
                    UpdateCanExecuteDefaultCommand();
                    break;
                }
        }
    }

    protected override bool GetCanExecuteDefaultCommand()
    {
        return base.GetCanExecuteDefaultCommand() && Index >= 0 && Index < HostNumberOfEntries;
    }
}