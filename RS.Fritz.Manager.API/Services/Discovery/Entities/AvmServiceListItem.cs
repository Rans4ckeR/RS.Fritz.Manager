namespace RS.Fritz.Manager.API;

using System.Runtime.Serialization;

[DataContract(Name = UPnPConstants.Service, Namespace = UPnPConstants.Device10AvmNamespace)]
internal readonly record struct AvmServiceListItem(
    [property: DataMember(Name = "serviceType", Order = 0)] string ServiceType,
    [property: DataMember(Name = "serviceId", Order = 1)] string ServiceId,
    [property: DataMember(Name = "controlURL", Order = 2)] string ControlUrl,
    [property: DataMember(Name = "eventSubURL", Order = 3)] string EventSubUrl,
    [property: DataMember(Name = "SCPDURL", Order = 4)] string ScpdUrl);