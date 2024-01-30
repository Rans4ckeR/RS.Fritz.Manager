namespace RS.Fritz.Manager.API;

using System.Runtime.Serialization;

[DataContract(Name = UPnPConstants.SpecVersion, Namespace = UPnPConstants.Device10AvmNamespace)]
internal readonly record struct AvmSpecVersion(
    [property: DataMember(Name = "major", Order = 0)] int Major,
    [property: DataMember(Name = "minor", Order = 1)] int Minor);