namespace RS.Fritz.Manager.API
{
    using System.ServiceModel;

    [MessageContract(WrapperName = "GetTotalBytesReceivedResponse")]
    public sealed record WanCommonInterfaceConfigGetTotalBytesReceivedResponse
    {
        [MessageBodyMember(Name = "NewTotalBytesReceived")]
        public uint TotalBytesReceived { get; set; }
    }
}