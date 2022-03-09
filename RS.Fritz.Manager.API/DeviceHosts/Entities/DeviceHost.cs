namespace RS.Fritz.Manager.API;

using System.Runtime.Serialization;

[DataContract(Namespace = "")]
public sealed record DeviceHost
{
    [DataMember(Name = "Index", Order = 0)]
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public int Index { get; set; }

    [DataMember(Name = "IPAddress", Order = 1)]
    public string IpAddress { get; set; }

    [DataMember(Name = "MACAddress", Order = 2)]
    public string MacAddress { get; set; }

    [DataMember(Name = "Active", Order = 3)]
    public bool Active { get; set; }

    [DataMember(Name = "HostName", Order = 4)]
    public string HostName { get; set; }

    [DataMember(Name = "InterfaceType", Order = 5)]
    public string InterfaceType { get; set; }

    [DataMember(Name = "X_AVM-DE_Port", Order = 6)]
    public ushort Port { get; set; }

    [DataMember(Name = "X_AVM-DE_Speed", Order = 7)]
    public ushort Speed { get; set; }

    [DataMember(Name = "X_AVM-DE_UpdateAvailable", Order = 8)]
    public bool UpdateAvailable { get; set; }

    [DataMember(Name = "X_AVM-DE_UpdateSuccessful", Order = 9)]
    public string UpdateSuccessful { get; set; }

    [DataMember(Name = "X_AVM-DE_InfoURL", Order = 10)]
    public string InfoUrl { get; set; }

    [DataMember(Name = "X_AVM-DE_Model", Order = 11)]
    public string Model { get; set; }

    [DataMember(Name = "X_AVM-DE_URL", Order = 12)]
    public string Url { get; set; }

    [DataMember(Name = "X_AVM-DE_Guest", Order = 13)]
    public bool Guest { get; set; }

    [DataMember(Name = "X_AVM-DE_VPN", Order = 14)]
    public bool Vpn { get; set; }

    [DataMember(Name = "X_AVM-DE_WANAccess", Order = 15)]
    public string WanAccess { get; set; }

    [DataMember(Name = "X_AVM-DE_Disallow", Order = 16)]
    public bool Disallow { get; set; }

#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
}