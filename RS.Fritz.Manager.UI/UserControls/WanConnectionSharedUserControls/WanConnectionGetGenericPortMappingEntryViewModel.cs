namespace RS.Fritz.Manager.UI;

internal abstract class WanConnectionGetGenericPortMappingEntryViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger) : FritzServiceViewModel(deviceLoginInfo, logger)
{
    private ushort? index;
    private ushort? portMappingNumberOfEntries;
    private KeyValuePair<WanConnectionGetGenericPortMappingEntryResponse?, UPnPFault?>? wanConnectionGetGenericPortMappingEntryResponse;

    public ushort? Index
    {
        get => index;
        set
        {
            if (SetProperty(ref index, value))
                UpdateAndNotifyCanExecuteDefaultCommand();
        }
    }

    public ushort? PortMappingNumberOfEntries
    {
        get => portMappingNumberOfEntries;
        set
        {
            if (SetProperty(ref portMappingNumberOfEntries, value))
                UpdateAndNotifyCanExecuteDefaultCommand();
        }
    }

    public KeyValuePair<WanConnectionGetGenericPortMappingEntryResponse?, UPnPFault?>? WanConnectionGetGenericPortMappingEntryResponse
    {
        get => wanConnectionGetGenericPortMappingEntryResponse;
        protected set => _ = SetProperty(ref wanConnectionGetGenericPortMappingEntryResponse, value);
    }

    protected override bool GetCanExecuteDefaultCommand()
        => base.GetCanExecuteDefaultCommand() && Index >= 0 && Index < PortMappingNumberOfEntries;
}