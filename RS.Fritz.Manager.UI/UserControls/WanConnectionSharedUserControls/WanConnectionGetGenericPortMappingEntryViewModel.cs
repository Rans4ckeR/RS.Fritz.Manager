namespace RS.Fritz.Manager.UI;

using System.ComponentModel;

internal abstract class WanConnectionGetGenericPortMappingEntryViewModel : FritzServiceViewModel
{
    private ushort? index;
    private ushort? portMappingNumberOfEntries;
    private KeyValuePair<WanConnectionGetGenericPortMappingEntryResponse?, UPnPFault?>? wanConnectionGetGenericPortMappingEntryResponse;

    protected WanConnectionGetGenericPortMappingEntryViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger)
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

    public ushort? PortMappingNumberOfEntries
    {
        get => portMappingNumberOfEntries;
        set
        {
            if (SetProperty(ref portMappingNumberOfEntries, value))
                DefaultCommand.NotifyCanExecuteChanged();
        }
    }

    public KeyValuePair<WanConnectionGetGenericPortMappingEntryResponse?, UPnPFault?>? WanConnectionGetGenericPortMappingEntryResponse
    {
        get => wanConnectionGetGenericPortMappingEntryResponse;
        protected set { _ = SetProperty(ref wanConnectionGetGenericPortMappingEntryResponse, value); }
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
        return base.GetCanExecuteDefaultCommand() && Index >= 0 && Index < PortMappingNumberOfEntries;
    }
}