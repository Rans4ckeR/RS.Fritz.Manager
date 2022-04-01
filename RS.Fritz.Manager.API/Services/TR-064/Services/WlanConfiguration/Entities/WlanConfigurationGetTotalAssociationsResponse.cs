namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetTotalAssociationsResponse")]
public readonly record struct WlanConfigurationGetTotalAssociationsResponse(
    [property: MessageBodyMember(Name = "NewTotalAssociations")] ushort TotalAssociations);