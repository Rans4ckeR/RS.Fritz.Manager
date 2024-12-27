namespace RS.Fritz.Manager.UI;

internal sealed class UserInterfaceDoManualUpdateViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger)
    : ManualOperationViewModel<UserInterfaceDoManualUpdateRequest, UserInterfaceDoManualUpdateResponse>(deviceLoginInfo, logger, "DoManualUpdate", "Manual Update", static (d, r) => d.UserInterfaceDoManualUpdateAsync(r))
{
    public string? DownloadUrl
    {
        get;
        set
        {
            if (SetProperty(ref field, value))
                UpdateAndNotifyCanExecuteDefaultCommand();
        }
    }

    public bool? AllowDowngrade
    {
        get;
        set
        {
            if (SetProperty(ref field, value))
                UpdateAndNotifyCanExecuteDefaultCommand();
        }
    }

    protected override UserInterfaceDoManualUpdateRequest BuildRequest()
        => new(DownloadUrl!, AllowDowngrade!.Value);

    protected override bool GetCanExecuteDefaultCommand()
        => base.GetCanExecuteDefaultCommand() && AllowDowngrade.HasValue;
}