namespace RS.Fritz.Manager.API;

using System.Runtime.Serialization;

[DataContract(Namespace = "")]
public readonly record struct DeviceHost(
    [property: DataMember(Name = "Index", Order = 0)] int Index,
    [property: DataMember(Name = "IPAddress", Order = 1)] string IpAddress,
    [property: DataMember(Name = "MACAddress", Order = 2)] string MacAddress,
    [property: DataMember(Name = "Active", Order = 3)] bool Active,
    [property: DataMember(Name = "HostName", Order = 4)] string HostName,
    [property: DataMember(Name = "InterfaceType", Order = 5)] string InterfaceType,
    [property: DataMember(Name = "X_AVM-DE_Port", Order = 6)] ushort Port,
    [property: DataMember(Name = "X_AVM-DE_Speed", Order = 7)] ushort Speed,
    [property: DataMember(Name = "X_AVM-DE_UpdateAvailable", Order = 8)] bool UpdateAvailable,
    [property: DataMember(Name = "X_AVM-DE_UpdateSuccessful", Order = 9)] string UpdateSuccessful,
    [property: DataMember(Name = "X_AVM-DE_InfoURL", Order = 10)] string InfoUrl,
    [property: DataMember(Name = "X_AVM-DE_Model", Order = 11)] string Model,
    [property: DataMember(Name = "X_AVM-DE_URL", Order = 12)] string Url,
    [property: DataMember(Name = "X_AVM-DE_Guest", Order = 13)] bool Guest,
    [property: DataMember(Name = "X_AVM-DE_VPN", Order = 14)] bool Vpn,
    [property: DataMember(Name = "X_AVM-DE_WANAccess", Order = 15)] string WanAccess,
    [property: DataMember(Name = "X_AVM-DE_Disallow", Order = 16)] bool Disallow);