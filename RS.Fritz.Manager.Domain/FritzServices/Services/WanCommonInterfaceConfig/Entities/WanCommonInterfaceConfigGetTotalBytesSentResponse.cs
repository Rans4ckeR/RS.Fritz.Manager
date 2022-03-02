namespace RS.Fritz.Manager.Domain
{
    using System.ServiceModel;

    [MessageContract(WrapperName = "GetTotalBytesSentResponse")]
    public sealed record WanCommonInterfaceConfigGetTotalBytesSentResponse
    {
        [MessageBodyMember(Name = "NewTotalBytesSent")]
        public uint TotalBytesSent { get; set; }
    }
}