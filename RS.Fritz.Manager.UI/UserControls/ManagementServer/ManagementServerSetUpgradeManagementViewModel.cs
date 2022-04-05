namespace RS.Fritz.Manager.UI;

using System.ComponentModel;

internal sealed class ManagementServerSetUpgradeManagementViewModel : ExecuteOperationViewModel<ManagementServerSetUpgradeManagementRequest, ManagementServerSetUpgradeManagementResponse>
{
    private bool? upgradesManaged;

    public ManagementServerSetUpgradeManagementViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger)
        : base(deviceLoginInfo, logger, "SetUpgradeManagement", "Update UpgradeManagement", (d, r) => d.ManagementServerSetUpgradeManagementAsync(r))
    {
    }

    public bool? UpgradesManaged
    {
        get => upgradesManaged;
        set
        {
            if (SetProperty(ref upgradesManaged, value))
                DefaultCommand.NotifyCanExecuteChanged();
        }
    }

    protected override ManagementServerSetUpgradeManagementRequest BuildRequest()
    {
        return new ManagementServerSetUpgradeManagementRequest(UpgradesManaged!.Value);
    }

    protected override void FritzServiceViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        base.FritzServiceViewModelPropertyChanged(sender, e);

        switch (e.PropertyName)
        {
            case nameof(UpgradesManaged):
                {
                    UpdateCanExecuteDefaultCommand();
                    break;
                }
        }
    }

    protected override bool GetCanExecuteDefaultCommand()
    {
        return base.GetCanExecuteDefaultCommand() && UpgradesManaged.HasValue;
    }
}