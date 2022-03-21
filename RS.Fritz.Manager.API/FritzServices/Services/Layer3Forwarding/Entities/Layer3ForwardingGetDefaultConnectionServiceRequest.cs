namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetDefaultConnectionService")]
public readonly record struct Layer3ForwardingGetDefaultConnectionServiceRequest;