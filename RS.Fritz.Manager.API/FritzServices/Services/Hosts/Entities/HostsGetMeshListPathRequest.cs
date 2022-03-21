namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetMeshListPath")]
public readonly record struct HostsGetMeshListPathRequest;