namespace RS.Fritz.Manager.UI;

using System.ComponentModel;

internal sealed class ManagementServerSetUpgradeManagementViewModel : ManualOperationViewModel<ManagementServerSetUpgradeManagementRequest, ManagementServerSetUpgradeManagementResponse>
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
        => new(UpgradesManaged!.Value);

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
        => base.GetCanExecuteDefaultCommand() && UpgradesManaged.HasValue;
}