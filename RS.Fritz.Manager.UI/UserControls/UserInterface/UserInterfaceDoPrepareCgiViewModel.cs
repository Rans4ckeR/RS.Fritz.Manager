﻿namespace RS.Fritz.Manager.UI;

internal sealed class UserInterfaceDoPrepareCgiViewModel : ExecuteOperationViewModel<UserInterfaceDoPrepareCgiRequest, UserInterfaceDoPrepareCgiResponse>
{
    public UserInterfaceDoPrepareCgiViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger)
        : base(deviceLoginInfo, logger, "DoPrepareCgi", "Prepare Cgi", (d, _) => d.UserInterfaceDoPrepareCgiAsync())
    {
    }
}