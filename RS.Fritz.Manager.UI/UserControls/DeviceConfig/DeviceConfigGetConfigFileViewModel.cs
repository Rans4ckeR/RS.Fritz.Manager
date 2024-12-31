namespace RS.Fritz.Manager.UI;

internal sealed class DeviceConfigGetConfigFileViewModel(DeviceLoginInfo deviceLoginInfo, ILogger<DeviceConfigGetConfigFileViewModel> logger)
    : ManualOperationViewModel<DeviceConfigGetConfigFileRequest, DeviceConfigGetConfigFileResponse>(deviceLoginInfo, logger, "GetConfigFile", "Get Config File URL", static (d, r) => d.DeviceConfigGetConfigFileAsync(r))
{
    public string? Password
    {
        get;
        set
        {
            if (SetProperty(ref field, value))
                UpdateAndNotifyCanExecuteDefaultCommand();
        }
    }

    protected override DeviceConfigGetConfigFileRequest BuildRequest()
        => new(Password!);
}