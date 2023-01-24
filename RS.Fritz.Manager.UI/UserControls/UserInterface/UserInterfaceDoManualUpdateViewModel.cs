namespace RS.Fritz.Manager.UI;

using System.ComponentModel;

internal sealed class UserInterfaceDoManualUpdateViewModel : ManualOperationViewModel<UserInterfaceDoManualUpdateRequest, UserInterfaceDoManualUpdateResponse>
{
    private string? downloadUrl;
    private bool? allowDowngrade;

    public UserInterfaceDoManualUpdateViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger)
        : base(deviceLoginInfo, logger, "DoManualUpdate", "Manual Update", (d, r) => d.UserInterfaceDoManualUpdateAsync(r))
    {
    }

    public string? DownloadUrl
    {
        get => downloadUrl;
        set
        {
            if (SetProperty(ref downloadUrl, value))
                DefaultCommand.NotifyCanExecuteChanged();
        }
    }

    public bool? AllowDowngrade
    {
        get => allowDowngrade;
        set
        {
            if (SetProperty(ref allowDowngrade, value))
                DefaultCommand.NotifyCanExecuteChanged();
        }
    }

    protected override UserInterfaceDoManualUpdateRequest BuildRequest()
    {
        return new(DownloadUrl!, AllowDowngrade!.Value);
    }

    protected override void FritzServiceViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        base.FritzServiceViewModelPropertyChanged(sender, e);

        switch (e.PropertyName)
        {
            case nameof(DownloadUrl):
            case nameof(AllowDowngrade):
                {
                    UpdateCanExecuteDefaultCommand();
                    break;
                }
        }
    }

    protected override bool GetCanExecuteDefaultCommand()
    {
        return base.GetCanExecuteDefaultCommand() && AllowDowngrade.HasValue;
    }
}