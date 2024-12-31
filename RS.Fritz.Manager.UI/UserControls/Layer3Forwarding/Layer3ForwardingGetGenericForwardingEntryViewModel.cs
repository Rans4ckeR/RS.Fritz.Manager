namespace RS.Fritz.Manager.UI;

internal sealed class Layer3ForwardingGetGenericForwardingEntryViewModel(DeviceLoginInfo deviceLoginInfo, ILogger<Layer3ForwardingGetGenericForwardingEntryViewModel> logger)
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

    public ushort? ForwardNumberOfEntries
    {
        get;
        set
        {
            if (SetProperty(ref field, value))
                UpdateAndNotifyCanExecuteDefaultCommand();
        }
    }

    public KeyValuePair<Layer3ForwardingGetGenericForwardingEntryResponse?, UPnPFault?>?
        Layer3ForwardingGetGenericForwardingEntryResponse
    {
        get;
        private set => _ = SetProperty(ref field, value);
    }

    protected override async ValueTask DoExecuteDefaultCommandAsync(CancellationToken cancellationToken)
        => Layer3ForwardingGetGenericForwardingEntryResponse = await ExecuteApiAsync(q => q.Layer3ForwardingGetGenericForwardingEntryAsync(new(Index!.Value))).ConfigureAwait(true);

    protected override bool GetCanExecuteDefaultCommand()
        => base.GetCanExecuteDefaultCommand() && Index >= 0 && Index < ForwardNumberOfEntries;
}