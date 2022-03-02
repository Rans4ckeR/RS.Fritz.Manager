namespace RS.Fritz.Manager.Domain
{
    using System.ServiceModel;

    [MessageContract(WrapperName = "GetGenericHostEntry")]
    public sealed record HostsGetGenericHostEntryRequest
    {
        [MessageBodyMember(Name = "NewIndex")]
        public ushort Index { get; set; }
    }
}