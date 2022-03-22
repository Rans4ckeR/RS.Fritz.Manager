namespace RS.Fritz.Manager.API;

using System.Runtime.Serialization;

[DataContract(Name = "icon", Namespace = "urn:dslforum-org:device-1-0")]
public readonly record struct IconListItem(
    [property: DataMember(Name = "mimetype", Order = 0)] string Mimetype,
    [property: DataMember(Name = "width", Order = 1)] int Width,
    [property: DataMember(Name = "height", Order = 2)] int Height,
    [property: DataMember(Name = "depth", Order = 3)] int Depth,
    [property: DataMember(Name = "url", Order = 4)] string Url);