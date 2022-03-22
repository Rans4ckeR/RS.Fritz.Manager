namespace RS.Fritz.Manager.API;

using System.Runtime.Serialization;

[DataContract(Name = "specVersion", Namespace = "urn:dslforum-org:device-1-0")]
public readonly record struct SpecVersion(
    [property: DataMember(Name = "major", Order = 0)] int Major,
    [property: DataMember(Name = "minor", Order = 1)] int Minor);