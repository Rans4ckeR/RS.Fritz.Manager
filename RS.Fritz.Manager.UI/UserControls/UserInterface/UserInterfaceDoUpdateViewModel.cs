namespace RS.Fritz.Manager.UI;
internal sealed class UserInterfaceDoUpdateViewModel : ManualOperationViewModel<UserInterfaceDoUpdateRequest, UserInterfaceDoUpdateResponse>
{
    public UserInterfaceDoUpdateViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger)
        : base(deviceLoginInfo, logger, "DoUpdate", "Update", (d, _) => d.UserInterfaceDoUpdateAsync())
    {
    }
}