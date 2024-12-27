namespace RS.Fritz.Manager.UI;

internal sealed class DeviceConfigCreateUrlSidViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger)
    : ManualOperationViewModel<DeviceConfigCreateUrlSidRequest, DeviceConfigCreateUrlSidResponse>(deviceLoginInfo, logger, "CreateUrlSid", "Create Url Sid", static (d, _) => d.DeviceConfigCreateUrlSidAsync());