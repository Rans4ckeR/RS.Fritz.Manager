namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetMeshListPathResponse")]
public readonly record struct HostsGetMeshListPathResponse(
    [property: MessageBodyMember(Name = "NewX_AVM-DE_MeshListPath")] string MeshListPath);