namespace RS.Fritz.Manager.API;

using System.Runtime.Serialization;

[DataContract(Name = "systemVersion", Namespace = "urn:dslforum-org:device-1-0")]
public readonly record struct SystemVersion(
    [property: DataMember(Name = "HW", Order = 0)] int HW,
    [property: DataMember(Name = "Major", Order = 1)] int Major,
    [property: DataMember(Name = "Minor", Order = 2)] int Minor,
    [property: DataMember(Name = "Patch", Order = 3)] int Patch,
    [property: DataMember(Name = "Buildnumber", Order = 4)] int BuildNumber,
    [property: DataMember(Name = "Display", Order = 5)] string Display);