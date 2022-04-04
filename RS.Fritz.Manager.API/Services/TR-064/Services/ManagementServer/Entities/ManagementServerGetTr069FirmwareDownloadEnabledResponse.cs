namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetTr069FirmwareDownloadEnabledResponse")]
public readonly record struct ManagementServerGetTr069FirmwareDownloadEnabledResponse(
    [property: MessageBodyMember(Name = "NewTR069FirmwareDownloadEnabled")] bool Tr069FirmwareDownloadEnabled);