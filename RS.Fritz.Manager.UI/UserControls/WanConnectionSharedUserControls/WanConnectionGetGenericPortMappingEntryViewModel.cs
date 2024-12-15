namespace RS.Fritz.Manager.UI;

internal abstract class WanConnectionGetGenericPortMappingEntryViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger) : FritzServiceViewModel(deviceLoginInfo, logger)
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

    public ushort? PortMappingNumberOfEntries
    {
        get;
        set
        {
            if (SetProperty(ref field, value))
                UpdateAndNotifyCanExecuteDefaultCommand();
        }
    }

    public KeyValuePair<WanConnectionGetGenericPortMappingEntryResponse?, UPnPFault?>? WanConnectionGetGenericPortMappingEntryResponse
    {
        get;
        protected set => _ = SetProperty(ref field, value);
    }

    protected override bool GetCanExecuteDefaultCommand()
        => base.GetCanExecuteDefaultCommand() && Index >= 0 && Index < PortMappingNumberOfEntries;
}