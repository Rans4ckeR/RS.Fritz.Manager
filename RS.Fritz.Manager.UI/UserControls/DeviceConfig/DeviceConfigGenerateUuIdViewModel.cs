namespace RS.Fritz.Manager.UI;

internal sealed class DeviceConfigGenerateUuIdViewModel(DeviceLoginInfo deviceLoginInfo, ILogger<DeviceConfigGenerateUuIdViewModel> logger)
    : ManualOperationViewModel<DeviceConfigGenerateUuIdRequest, DeviceConfigGenerateUuIdResponse>(deviceLoginInfo, logger, "GenerateUuId", "Generate UuId", static (d, _) => d.DeviceConfigGenerateUuIdAsync());