namespace RS.Fritz.Manager.UI;

internal sealed class UserInterfaceSetInternationalConfigViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger)
    : ManualOperationViewModel<UserInterfaceSetInternationalConfigRequest, UserInterfaceSetInternationalConfigResponse>(deviceLoginInfo, logger, "SetInternationalConfig", "Set InternationalConfig", static (d, r) => d.UserInterfaceSetInternationalConfigAsync(r))
{
    public string? Language
    {
        get;
        set
        {
            if (SetProperty(ref field, value))
                UpdateAndNotifyCanExecuteDefaultCommand();
        }
    }

    public string? Country
    {
        get;
        set
        {
            if (SetProperty(ref field, value))
                UpdateAndNotifyCanExecuteDefaultCommand();
        }
    }

    public string? Annex
    {
        get;
        set
        {
            if (SetProperty(ref field, value))
                UpdateAndNotifyCanExecuteDefaultCommand();
        }
    }

    protected override UserInterfaceSetInternationalConfigRequest BuildRequest()
        => new(Language!, Country!, Annex!);
}