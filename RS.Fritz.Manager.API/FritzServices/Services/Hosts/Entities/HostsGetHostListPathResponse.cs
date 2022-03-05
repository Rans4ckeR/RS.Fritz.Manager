namespace RS.Fritz.Manager.API
{
    using System.ServiceModel;

    [MessageContract(WrapperName = "GetHostListPathResponse")]
    public sealed record HostsGetHostListPathResponse
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        [MessageBodyMember(Name = "NewX_AVM-DE_HostListPath")]
        public string HostListPath { get; set; }
    }
}