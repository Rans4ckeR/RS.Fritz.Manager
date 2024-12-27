namespace RS.Fritz.Manager.UI;

internal sealed class UserInterfaceDoUpdateViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger)
    : ManualOperationViewModel<UserInterfaceDoUpdateRequest, UserInterfaceDoUpdateResponse>(deviceLoginInfo, logger, "DoUpdate", "Update", static (d, _) => d.UserInterfaceDoUpdateAsync());