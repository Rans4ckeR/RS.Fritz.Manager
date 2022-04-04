namespace RS.Fritz.Manager.API;

using System.Runtime.Serialization;

[DataContract(Name = "UPnPError", Namespace = "urn:dslforum-org:control-1-0")]
public readonly record struct UPnPFault2(
    [property: DataMember(Name = "errorCode")] ushort ErrorCode,
    [property: DataMember(Name = "errorDescription")] string ErrorDescription);