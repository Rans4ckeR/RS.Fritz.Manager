namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetGenericPortMappingEntryResponse")]
public readonly record struct WanConnectionGetGenericPortMappingEntryResponse(
    [property: MessageBodyMember(Name = "NewRemoteHost")] string RemoteHost,
    [property: MessageBodyMember(Name = "NewExternalPort")] ushort ExternalPort,
    [property: MessageBodyMember(Name = "NewProtocol")] string Protocol,
    [property: MessageBodyMember(Name = "NewInternalPort")] ushort InternalPort,
    [property: MessageBodyMember(Name = "NewInternalClient")] string InternalClient,
    [property: MessageBodyMember(Name = "NewEnabled")] bool Enabled,
    [property: MessageBodyMember(Name = "NewPortMappingDescription")] string PortMappingDescription,
    [property: MessageBodyMember(Name = "NewLeaseDuration")] uint LeaseDuration);