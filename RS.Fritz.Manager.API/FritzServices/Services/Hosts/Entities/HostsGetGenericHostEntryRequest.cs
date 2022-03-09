namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetGenericHostEntry")]
public sealed record HostsGetGenericHostEntryRequest
{
    [MessageBodyMember(Name = "NewIndex")]
    public ushort Index { get; set; }
}