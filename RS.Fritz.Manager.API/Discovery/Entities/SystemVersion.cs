namespace RS.Fritz.Manager.API
{
    using System.Runtime.Serialization;

    [DataContract(Name = "systemVersion", Namespace = "urn:dslforum-org:device-1-0")]
    public sealed record SystemVersion
    {
        [DataMember(Name = "HW", Order = 0)]
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public int HW { get; set; }

        [DataMember(Name = "Major", Order = 1)]
        public int Major { get; set; }

        [DataMember(Name = "Minor", Order = 2)]
        public int Minor { get; set; }

        [DataMember(Name = "Patch", Order = 3)]
        public int Patch { get; set; }

        [DataMember(Name = "Buildnumber", Order = 4)]
        public int Buildnumber { get; set; }

        [DataMember(Name = "Display", Order = 5)]
        public string Display { get; set; }
    }
}