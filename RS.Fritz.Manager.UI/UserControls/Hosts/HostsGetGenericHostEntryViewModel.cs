namespace RS.Fritz.Manager.UI;

using System.ComponentModel;

internal sealed class HostsGetGenericHostEntryViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger)
    : FritzServiceViewModel(deviceLoginInfo, logger)
{
    private ushort? index;
    private ushort? hostNumberOfEntries;
    private KeyValuePair<HostsGetGenericHostEntryResponse?, UPnPFault?>? hostsGetGenericHostEntryResponse;

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

    public KeyValuePair<HostsGetGenericHostEntryResponse?, UPnPFault?>? HostsGetGenericHostEntryResponse
    {
        get => hostsGetGenericHostEntryResponse;
        private set => _ = SetProperty(ref hostsGetGenericHostEntryResponse, value);
    }

    protected override async ValueTask DoExecuteDefaultCommandAsync(CancellationToken cancellationToken)
        => HostsGetGenericHostEntryResponse = await ExecuteApiAsync(q => q.HostsGetGenericHostEntryAsync(new(Index!.Value))).ConfigureAwait(true);

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
        => base.GetCanExecuteDefaultCommand() && Index >= 0 && Index < HostNumberOfEntries;
}