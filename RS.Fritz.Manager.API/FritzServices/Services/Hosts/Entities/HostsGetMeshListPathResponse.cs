namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetMeshListPathResponse")]
public sealed record HostsGetMeshListPathResponse
{
    [MessageBodyMember(Name = "NewX_AVM-DE_MeshListPath")]
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public string MeshListPath { get; set; }
}