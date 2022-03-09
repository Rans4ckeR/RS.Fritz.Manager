namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetDefaultConnectionService")]
public sealed record Layer3ForwardingGetDefaultConnectionServiceRequest;