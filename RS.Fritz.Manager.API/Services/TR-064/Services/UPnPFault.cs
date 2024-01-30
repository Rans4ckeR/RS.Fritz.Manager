namespace RS.Fritz.Manager.API;

using System.Runtime.Serialization;

[DataContract(Name = "UPnPError", Namespace = UPnPConstants.Control10Namespace)]
public readonly record struct UPnPFault(
    [property: DataMember(Name = "errorCode")] ushort ErrorCode,
    [property: DataMember(Name = "errorDescription")] string ErrorDescription);