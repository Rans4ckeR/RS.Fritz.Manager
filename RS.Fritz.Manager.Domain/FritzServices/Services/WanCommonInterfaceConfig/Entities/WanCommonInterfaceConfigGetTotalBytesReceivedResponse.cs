namespace RS.Fritz.Manager.Domain
{
    using System.ServiceModel;

    [MessageContract(WrapperName = "GetTotalBytesReceivedResponse")]
    public sealed record WanCommonInterfaceConfigGetTotalBytesReceivedResponse
    {
        [MessageBodyMember(Name = "NewTotalBytesReceived")]
        public uint TotalBytesReceived { get; set; }
    }
}