namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GenerateUuIdResponse")]
public readonly record struct DeviceConfigGenerateUuIdResponse(
    [property: MessageBodyMember(Name = "NewUUID")] string UuId);