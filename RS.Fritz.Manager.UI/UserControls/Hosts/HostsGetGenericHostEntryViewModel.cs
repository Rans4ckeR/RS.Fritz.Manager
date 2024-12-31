namespace RS.Fritz.Manager.UI;

internal sealed class HostsGetGenericHostEntryViewModel(DeviceLoginInfo deviceLoginInfo, ILogger<HostsGetGenericHostEntryViewModel> logger)
    : FritzServiceViewModel(deviceLoginInfo, logger)
{
    public ushort? Index
    {
        get;
        set
        {
            if (SetProperty(ref field, value))
                UpdateAndNotifyCanExecuteDefaultCommand();
        }
    }

    public ushort? HostNumberOfEntries
    {
        get;
        set
        {
            if (SetProperty(ref field, value))
                UpdateAndNotifyCanExecuteDefaultCommand();
        }
    }

    public KeyValuePair<HostsGetGenericHostEntryResponse?, UPnPFault?>? HostsGetGenericHostEntryResponse
    {
        get;
        private set => _ = SetProperty(ref field, value);
    }

    protected override async ValueTask DoExecuteDefaultCommandAsync(CancellationToken cancellationToken)
        => HostsGetGenericHostEntryResponse = await ExecuteApiAsync(q => q.HostsGetGenericHostEntryAsync(new(Index!.Value))).ConfigureAwait(true);

    protected override bool GetCanExecuteDefaultCommand()
        => base.GetCanExecuteDefaultCommand() && Index >= 0 && Index < HostNumberOfEntries;
}