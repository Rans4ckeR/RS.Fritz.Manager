namespace RS.Fritz.Manager.UI;

internal sealed class UserInterfaceDoUpdateViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger)
    : ManualOperationViewModel<UserInterfaceDoUpdateRequest, UserInterfaceDoUpdateResponse>(deviceLoginInfo, logger, "DoUpdate", "Update", (d, _) => d.UserInterfaceDoUpdateAsync())
{
}