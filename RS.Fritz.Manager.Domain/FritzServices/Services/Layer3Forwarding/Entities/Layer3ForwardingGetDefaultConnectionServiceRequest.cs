namespace RS.Fritz.Manager.Domain
{
    using System.ServiceModel;

    [MessageContract(WrapperName = "GetDefaultConnectionService")]
    public sealed record Layer3ForwardingGetDefaultConnectionServiceRequest
    {
    }
}