namespace RS.Fritz.Manager.Domain
{
    using System.ServiceModel;

    [MessageContract(WrapperName = "GetGenericHostEntry")]
#pragma warning disable S101 // Types should be named in PascalCase
    public sealed record HostsGetGenericHostEntryRequest
    {
        [MessageBodyMember(Name = "NewIndex")]
        public ushort Index { get; set; }
#pragma warning restore S101 // Types should be named in PascalCase
    }
}