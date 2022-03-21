namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetGenericHostEntry")]
public readonly record struct HostsGetGenericHostEntryRequest(
    [property: MessageBodyMember(Name = "NewIndex")] ushort Index);