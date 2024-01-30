namespace RS.Fritz.Manager.UI;

internal sealed class UserInterfaceSetInternationalConfigViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger)
    : ManualOperationViewModel<UserInterfaceSetInternationalConfigRequest, UserInterfaceSetInternationalConfigResponse>(deviceLoginInfo, logger, "SetInternationalConfig", "Set InternationalConfig", (d, r) => d.UserInterfaceSetInternationalConfigAsync(r))
{
    private string? language;
    private string? country;
    private string? annex;

    public string? Language
    {
        get => language;
        set
        {
            if (SetProperty(ref language, value))
                UpdateAndNotifyCanExecuteDefaultCommand();
        }
    }

    public string? Country
    {
        get => country;
        set
        {
            if (SetProperty(ref country, value))
                UpdateAndNotifyCanExecuteDefaultCommand();
        }
    }

    public string? Annex
    {
        get => annex;
        set
        {
            if (SetProperty(ref annex, value))
                UpdateAndNotifyCanExecuteDefaultCommand();
        }
    }

    protected override UserInterfaceSetInternationalConfigRequest BuildRequest()
        => new(Language!, Country!, Annex!);
}