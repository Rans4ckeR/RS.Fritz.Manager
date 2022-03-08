namespace RS.Fritz.Manager.API
{
    using System.Runtime.Serialization;

    [DataContract(Name = "root", Namespace = "urn:dslforum-org:device-1-0")]
    public sealed record UPnPDescription
    {
        [DataMember(Name = "specVersion", Order = 0)]
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public SpecVersion SpecVersion { get; set; }

        [DataMember(Name = "systemVersion", Order = 1)]
        public SystemVersion SystemVersion { get; set; }

        [DataMember(Name = "device", Order = 2)]
        public Device Device { get; set; }
    }
}