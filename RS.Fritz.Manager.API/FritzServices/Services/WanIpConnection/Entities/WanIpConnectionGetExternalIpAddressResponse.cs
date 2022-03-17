namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetExternalIpAddressResponse")]
public sealed record WanIpConnectionGetExternalIpAddressResponse
{
    [MessageBodyMember(Name = "NewExternalIPAddress")]
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public string ExternalIpAddress { get; set; }
}