namespace RS.Fritz.Manager.UI;

internal sealed class UserInterfaceDoUpdateViewModel : ExecuteOperationViewModel<UserInterfaceDoUpdateRequest, UserInterfaceDoUpdateResponse>
{
    public UserInterfaceDoUpdateViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger)
        : base(deviceLoginInfo, logger, "DoUpdate", "Update", (d, _) => d.DoUpdateAsync())
    {
    }
}