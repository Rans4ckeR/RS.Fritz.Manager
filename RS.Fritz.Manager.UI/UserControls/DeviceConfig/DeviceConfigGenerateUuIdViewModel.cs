namespace RS.Fritz.Manager.UI;

internal sealed class DeviceConfigGenerateUuIdViewModel : ManualOperationViewModel<DeviceConfigGenerateUuIdRequest, DeviceConfigGenerateUuIdResponse>
{
    public DeviceConfigGenerateUuIdViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger)
        : base(deviceLoginInfo, logger, "GenerateUuId", "Generate UuId", (d, _) => d.DeviceConfigGenerateUuIdAsync())
    {
    }
}