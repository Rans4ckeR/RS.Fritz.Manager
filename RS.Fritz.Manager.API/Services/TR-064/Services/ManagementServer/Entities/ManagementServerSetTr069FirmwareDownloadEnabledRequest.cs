namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "SetTr069FirmwareDownloadEnabled")]
public readonly record struct ManagementServerSetTr069FirmwareDownloadEnabledRequest(
    [property: MessageBodyMember(Name = "NewTR069FirmwareDownloadEnabled")] bool Tr069FirmwareDownloadEnabled);