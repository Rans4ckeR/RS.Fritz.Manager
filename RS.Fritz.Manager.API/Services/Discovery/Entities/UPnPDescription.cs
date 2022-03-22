namespace RS.Fritz.Manager.API;

using System.Runtime.Serialization;

[DataContract(Name = "root", Namespace = "urn:dslforum-org:device-1-0")]
public readonly record struct UPnPDescription(
    [property: DataMember(Name = "specVersion", Order = 0)] SpecVersion SpecVersion,
    [property: DataMember(Name = "systemVersion", Order = 1)] SystemVersion SystemVersion,
    [property: DataMember(Name = "device", Order = 2)] Device Device);