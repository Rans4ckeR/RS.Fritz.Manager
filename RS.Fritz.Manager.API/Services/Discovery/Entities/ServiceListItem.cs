﻿namespace RS.Fritz.Manager.API;

using System.Runtime.Serialization;

[DataContract(Name = "service", Namespace = "urn:dslforum-org:device-1-0")]
public readonly record struct ServiceListItem(
    [property: DataMember(Name = "serviceType", Order = 0)] string ServiceType,
    [property: DataMember(Name = "serviceId", Order = 1)] string ServiceId,
    [property: DataMember(Name = "controlURL", Order = 2)] string ControlUrl,
    [property: DataMember(Name = "eventSubURL", Order = 3)] string EventSubUrl,
    [property: DataMember(Name = "SCPDURL", Order = 4)] string ScpdUrl);