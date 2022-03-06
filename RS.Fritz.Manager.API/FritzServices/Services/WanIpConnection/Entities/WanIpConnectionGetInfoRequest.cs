namespace RS.Fritz.Manager.API
{
    using System.ServiceModel;

    [MessageContract(WrapperName = "GetInfo")]
    public sealed record WanIpConnectionGetInfoRequest;
}