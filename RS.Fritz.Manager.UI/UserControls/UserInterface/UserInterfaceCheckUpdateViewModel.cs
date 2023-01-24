namespace RS.Fritz.Manager.UI;

internal sealed class UserInterfaceCheckUpdateViewModel : ManualOperationViewModel<UserInterfaceCheckUpdateRequest, UserInterfaceCheckUpdateResponse>
{
    public UserInterfaceCheckUpdateViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger)
        : base(deviceLoginInfo, logger, "CheckUpdate", "Check Update", (d, r) => d.UserInterfaceCheckUpdateAsync(r))
    {
    }
}