namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetGenericHostEntry")]
public readonly record struct HostsGetGenericHostEntryRequest(
    [property: MessageBodyMember(Name = "NewIndex")] ushort Index);