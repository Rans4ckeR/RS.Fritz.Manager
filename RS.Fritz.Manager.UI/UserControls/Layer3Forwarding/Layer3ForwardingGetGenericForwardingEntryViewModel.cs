namespace RS.Fritz.Manager.UI;

internal sealed class Layer3ForwardingGetGenericForwardingEntryViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger)
    : FritzServiceViewModel(deviceLoginInfo, logger)
{
    private ushort? index;
    private ushort? forwardNumberOfEntries;
    private KeyValuePair<Layer3ForwardingGetGenericForwardingEntryResponse?, UPnPFault?>? layer3ForwardingGetGenericForwardingEntryResponse;

    public ushort? Index
    {
        get => index;
        set
        {
            if (SetProperty(ref index, value))
                UpdateAndNotifyCanExecuteDefaultCommand();
        }
    }

    public ushort? ForwardNumberOfEntries
    {
        get => forwardNumberOfEntries;
        set
        {
            if (SetProperty(ref forwardNumberOfEntries, value))
                UpdateAndNotifyCanExecuteDefaultCommand();
        }
    }

    public KeyValuePair<Layer3ForwardingGetGenericForwardingEntryResponse?, UPnPFault?>? Layer3ForwardingGetGenericForwardingEntryResponse
    {
        get => layer3ForwardingGetGenericForwardingEntryResponse;
        private set => _ = SetProperty(ref layer3ForwardingGetGenericForwardingEntryResponse, value);
    }

    protected override async ValueTask DoExecuteDefaultCommandAsync(CancellationToken cancellationToken)
        => Layer3ForwardingGetGenericForwardingEntryResponse = await ExecuteApiAsync(q => q.Layer3ForwardingGetGenericForwardingEntryAsync(new(Index!.Value))).ConfigureAwait(true);

    protected override bool GetCanExecuteDefaultCommand()
        => base.GetCanExecuteDefaultCommand() && Index >= 0 && Index < ForwardNumberOfEntries;
}