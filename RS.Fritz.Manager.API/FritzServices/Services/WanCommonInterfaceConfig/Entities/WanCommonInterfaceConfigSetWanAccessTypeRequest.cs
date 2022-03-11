namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "SetWanAccessType")]
public sealed record WanCommonInterfaceConfigSetWanAccessTypeRequest
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    [MessageBodyMember(Name = "NewAccessType")]
    public string AccessType { get; set; }
}