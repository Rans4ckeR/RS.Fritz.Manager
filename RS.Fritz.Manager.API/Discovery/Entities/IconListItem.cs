namespace RS.Fritz.Manager.API
{
    using System.Runtime.Serialization;

    [DataContract(Name = "icon", Namespace = "urn:dslforum-org:device-1-0")]
    public sealed record IconListItem
    {
        [DataMember(Name = "mimetype", Order = 0)]
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public string Mimetype { get; set; }

        [DataMember(Name = "width", Order = 1)]
        public int Width { get; set; }

        [DataMember(Name = "height", Order = 2)]
        public int Height { get; set; }

        [DataMember(Name = "depth", Order = 3)]
        public int Depth { get; set; }

        [DataMember(Name = "url", Order = 4)]
        public string Url { get; set; }
    }
}