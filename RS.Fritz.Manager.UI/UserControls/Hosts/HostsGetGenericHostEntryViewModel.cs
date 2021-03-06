namespace RS.Fritz.Manager.UI;

using System.ComponentModel;

internal sealed class HostsGetGenericHostEntryViewModel : FritzServiceViewModel
{
    private ushort? index;
    private ushort? hostNumberOfEntries;
    private KeyValuePair<HostsGetGenericHostEntryResponse?, UPnPFault?>? hostsGetGenericHostEntryResponse;

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

    public KeyValuePair<HostsGetGenericHostEntryResponse?, UPnPFault?>? HostsGetGenericHostEntryResponse
    {
        get => hostsGetGenericHostEntryResponse;
        private set { _ = SetProperty(ref hostsGetGenericHostEntryResponse, value); }
    }

    protected override async Task DoExecuteDefaultCommandAsync(CancellationToken cancellationToken)
    {
        HostsGetGenericHostEntryResponse = await ExecuteApiAsync(q => q.HostsGetGenericHostEntryAsync(new HostsGetGenericHostEntryRequest(Index!.Value)));
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