namespace RS.Fritz.Manager.UI;

internal sealed class DeviceConfigCreateUrlSidViewModel : ManualOperationViewModel<DeviceConfigCreateUrlSidRequest, DeviceConfigCreateUrlSidResponse>
{
    public DeviceConfigCreateUrlSidViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger)
        : base(deviceLoginInfo, logger, "CreateUrlSid", "Create Url Sid", (d, _) => d.DeviceConfigCreateUrlSidAsync())
    {
    }
}