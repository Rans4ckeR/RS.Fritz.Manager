namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetHostListPath")]
public readonly record struct HostsGetHostListPathRequest;