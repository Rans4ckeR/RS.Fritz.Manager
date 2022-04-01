namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetTr069FirmwareDownloadEnabled")]
public readonly record struct ManagementServerGetTr069FirmwareDownloadEnabledRequest;