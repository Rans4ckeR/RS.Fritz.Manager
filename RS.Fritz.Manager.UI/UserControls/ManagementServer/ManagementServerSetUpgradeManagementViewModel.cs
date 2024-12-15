namespace RS.Fritz.Manager.UI;

internal sealed class ManagementServerSetUpgradeManagementViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger)
    : ManualOperationViewModel<ManagementServerSetUpgradeManagementRequest, ManagementServerSetUpgradeManagementResponse>(deviceLoginInfo, logger, "SetUpgradeManagement", "Update UpgradeManagement", (d, r) => d.ManagementServerSetUpgradeManagementAsync(r))
{
    public bool? UpgradesManaged
    {
        get;
        set
        {
            if (SetProperty(ref field, value))
                UpdateAndNotifyCanExecuteDefaultCommand();
        }
    }

    protected override ManagementServerSetUpgradeManagementRequest BuildRequest()
        => new(UpgradesManaged!.Value);

    protected override bool GetCanExecuteDefaultCommand()
        => base.GetCanExecuteDefaultCommand() && UpgradesManaged.HasValue;
}