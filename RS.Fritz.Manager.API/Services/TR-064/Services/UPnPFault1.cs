namespace RS.Fritz.Manager.API;

using System.Runtime.Serialization;

[DataContract(Name = "UPnPError", Namespace = "urn:schemas-upnp-org:control-1-0")]
public readonly record struct UPnPFault1(
    [property: DataMember(Name = "errorCode")] ushort ErrorCode,
    [property: DataMember(Name = "errorDescription")] string ErrorDescription);