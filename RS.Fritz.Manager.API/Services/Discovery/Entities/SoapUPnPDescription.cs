namespace RS.Fritz.Manager.API;

using System.Runtime.Serialization;

[DataContract(Name = UPnPConstants.Root, Namespace = UPnPConstants.Device10Namespace)]
internal readonly record struct SoapUPnPDescription(
    [property: DataMember(Name = "specVersion", Order = 0)] SoapSpecVersion SpecVersion,
    [property: DataMember(Name = "URLBase", Order = 1)] string? UrlBase,
    [property: DataMember(Name = "device", Order = 2)] SoapDevice Device);