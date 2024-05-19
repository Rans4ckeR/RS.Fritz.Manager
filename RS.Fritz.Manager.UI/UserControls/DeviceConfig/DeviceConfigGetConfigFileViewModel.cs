namespace RS.Fritz.Manager.UI;

internal sealed class
    DeviceConfigGetConfigFileViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger)
    : ManualOperationViewModel<DeviceConfigGetConfigFileRequest, DeviceConfigGetConfigFileResponse>(deviceLoginInfo, logger, "GetConfigFile", "Get Config File URL", (d, r) => d.DeviceConfigGetConfigFileAsync(r))
{
    private string? password;

    public string? Password
    {
        get => password;
        set
        {
            if (SetProperty(ref password, value))
                UpdateAndNotifyCanExecuteDefaultCommand();
        }
    }

    protected override DeviceConfigGetConfigFileRequest BuildRequest()
        => new(Password!);
}