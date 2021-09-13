namespace RS.Fritz.Manager.Domain
{
    using System.ServiceModel;

    [MessageContract(WrapperName = "GetInfo")]
    public sealed record WanDslInterfaceConfigGetInfoRequest;
}