namespace RS.Fritz.Manager.API;

using System.Runtime.Serialization;

[DataContract(Name = UPnPConstants.SystemVersion, Namespace = UPnPConstants.Device10AvmNamespace)]
internal readonly record struct AvmSystemVersion(
    [property: DataMember(Name = "HW", Order = 0)] int Hw,
    [property: DataMember(Name = "Major", Order = 1)] int Major,
    [property: DataMember(Name = "Minor", Order = 2)] int Minor,
    [property: DataMember(Name = "Patch", Order = 3)] int Patch,
    [property: DataMember(Name = "Buildnumber", Order = 4)] int BuildNumber,
    [property: DataMember(Name = "Display", Order = 5)] string Display);