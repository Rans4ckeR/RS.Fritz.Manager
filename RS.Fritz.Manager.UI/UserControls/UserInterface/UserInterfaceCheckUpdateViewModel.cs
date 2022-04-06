namespace RS.Fritz.Manager.UI;

using System.ComponentModel;

internal sealed class UserInterfaceCheckUpdateViewModel : ManualOperationViewModel<UserInterfaceCheckUpdateRequest, UserInterfaceCheckUpdateResponse>
{
    private string? laborVersion;

    public UserInterfaceCheckUpdateViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger)
        : base(deviceLoginInfo, logger, "CheckUpdate", "Check Update", (d, r) => d.UserInterfaceCheckUpdateAsync(r))
    {
    }

    public string? LaborVersion
    {
        get => laborVersion;
        set
        {
            if (SetProperty(ref laborVersion, value))
                DefaultCommand.NotifyCanExecuteChanged();
        }
    }

    protected override UserInterfaceCheckUpdateRequest BuildRequest()
    {
        return new UserInterfaceCheckUpdateRequest(LaborVersion!);
    }

    protected override void FritzServiceViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        base.FritzServiceViewModelPropertyChanged(sender, e);

        switch (e.PropertyName)
        {
            case nameof(LaborVersion):
                {
                    UpdateCanExecuteDefaultCommand();
                    break;
                }
        }
    }
}