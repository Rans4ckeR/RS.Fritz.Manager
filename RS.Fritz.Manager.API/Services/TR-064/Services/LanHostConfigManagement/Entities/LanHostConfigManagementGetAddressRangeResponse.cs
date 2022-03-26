namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetAddressRangeResponse")]
public readonly record struct LanHostConfigManagementGetAddressRangeResponse(
    [property: MessageBodyMember(Name = "NewMinAddress")] string MinAddress,
    [property: MessageBodyMember(Name = "NewMaxAddress")] string NaxAddress);