namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetMeshListPath")]
public sealed record HostsGetMeshListPathRequest;