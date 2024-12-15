using System.Runtime.Serialization;

namespace RS.Fritz.Manager.API;

[DataContract(Name = UPnPConstants.Icon, Namespace = UPnPConstants.Device10Namespace)]
internal readonly record struct SoapIconListItem(
    [property: DataMember(Name = "mimetype", Order = 0)] string Mimetype,
    [property: DataMember(Name = "width", Order = 1)] int Width,
    [property: DataMember(Name = "height", Order = 2)] int Height,
    [property: DataMember(Name = "depth", Order = 3)] int Depth,
    [property: DataMember(Name = "url", Order = 4)] string Url);