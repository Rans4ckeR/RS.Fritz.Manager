namespace RS.Fritz.Manager.UI;

internal sealed class UserInterfaceDoManualUpdateViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger)
    : ManualOperationViewModel<UserInterfaceDoManualUpdateRequest, UserInterfaceDoManualUpdateResponse>(deviceLoginInfo, logger, "DoManualUpdate", "Manual Update", (d, r) => d.UserInterfaceDoManualUpdateAsync(r))
{
    private string? downloadUrl;
    private bool? allowDowngrade;

    public string? DownloadUrl
    {
        get => downloadUrl;
        set
        {
            if (SetProperty(ref downloadUrl, value))
                UpdateAndNotifyCanExecuteDefaultCommand();
        }
    }

    public bool? AllowDowngrade
    {
        get => allowDowngrade;
        set
        {
            if (SetProperty(ref allowDowngrade, value))
                UpdateAndNotifyCanExecuteDefaultCommand();
        }
    }

    protected override UserInterfaceDoManualUpdateRequest BuildRequest()
        => new(DownloadUrl!, AllowDowngrade!.Value);

    protected override bool GetCanExecuteDefaultCommand()
        => base.GetCanExecuteDefaultCommand() && AllowDowngrade.HasValue;
}