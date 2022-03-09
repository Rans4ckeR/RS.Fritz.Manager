namespace RS.Fritz.Manager.API;

using System.Runtime.Serialization;

[DataContract(Name = "service", Namespace = "urn:dslforum-org:device-1-0")]
public sealed record ServiceListItem
{
    [DataMember(Name = "serviceType", Order = 0)]
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public string ServiceType { get; set; }

    [DataMember(Name = "serviceId", Order = 1)]
    public string ServiceId { get; set; }

    [DataMember(Name = "controlURL", Order = 2)]
    public string ControlUrl { get; set; }

    [DataMember(Name = "eventSubURL", Order = 3)]
    public string EventSubUrl { get; set; }

    [DataMember(Name = "SCPDURL", Order = 4)]
    public string ScpdUrl { get; set; }
}