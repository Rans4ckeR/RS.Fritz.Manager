namespace RS.Fritz.Manager.API
{
    using System.Runtime.Serialization;

    [DataContract(Name = "specVersion", Namespace = "urn:dslforum-org:device-1-0")]
    public sealed record SpecVersion
    {
        [DataMember(Name = "major", Order = 0)]
        public int Major { get; set; }

        [DataMember(Name = "minor", Order = 1)]
        public int Minor { get; set; }
    }
}