namespace RS.Fritz.Manager.Domain
{
    using System.ServiceModel;

    [MessageContract(WrapperName = "GetCommonLinkProperties")]

    public sealed record WanCommonInterfaceConfigGetCommonLinkPropertiesRequest;

}