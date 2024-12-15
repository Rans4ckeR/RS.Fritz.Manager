using System.Runtime.Serialization;

namespace RS.Fritz.Manager.API;

[DataContract(Name = UPnPConstants.Root, Namespace = UPnPConstants.Device10AvmNamespace)]
internal readonly record struct AvmUPnPDescription(
    [property: DataMember(Name = "specVersion", Order = 0)] AvmSpecVersion SpecVersion,
    [property: DataMember(Name = "systemVersion", Order = 1)] AvmSystemVersion SystemVersion,
    [property: DataMember(Name = "device", Order = 2)] AvmDevice Device);