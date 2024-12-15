using System.Runtime.Serialization;

namespace RS.Fritz.Manager.API;

[DataContract(Name = "UPnPError", Namespace = UPnPConstants.Control10AvmNamespace)]
public readonly record struct AvmUPnPFault(
    [property: DataMember(Name = "errorCode")] ushort ErrorCode,
    [property: DataMember(Name = "errorDescription")] string ErrorDescription);