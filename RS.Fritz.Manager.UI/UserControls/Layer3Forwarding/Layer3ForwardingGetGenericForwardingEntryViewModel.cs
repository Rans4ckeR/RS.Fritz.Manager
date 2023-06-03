namespace RS.Fritz.Manager.UI;

using System.ComponentModel;

internal sealed class Layer3ForwardingGetGenericForwardingEntryViewModel : FritzServiceViewModel
{
    private ushort? index;
    private ushort? forwardNumberOfEntries;
    private KeyValuePair<Layer3ForwardingGetGenericForwardingEntryResponse?, UPnPFault?>? layer3ForwardingGetGenericForwardingEntryResponse;

    public Layer3ForwardingGetGenericForwardingEntryViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger)
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

    public ushort? ForwardNumberOfEntries
    {
        get => forwardNumberOfEntries;
        set
        {
            if (SetProperty(ref forwardNumberOfEntries, value))
                DefaultCommand.NotifyCanExecuteChanged();
        }
    }

    public KeyValuePair<Layer3ForwardingGetGenericForwardingEntryResponse?, UPnPFault?>? Layer3ForwardingGetGenericForwardingEntryResponse
    {
        get => layer3ForwardingGetGenericForwardingEntryResponse;
        private set { _ = SetProperty(ref layer3ForwardingGetGenericForwardingEntryResponse, value); }
    }

    protected override async ValueTask DoExecuteDefaultCommandAsync(CancellationToken cancellationToken)
    {
        Layer3ForwardingGetGenericForwardingEntryResponse = await ExecuteApiAsync(q => q.Layer3ForwardingGetGenericForwardingEntryAsync(new(Index!.Value)));
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
        return base.GetCanExecuteDefaultCommand() && Index >= 0 && Index < ForwardNumberOfEntries;
    }
}