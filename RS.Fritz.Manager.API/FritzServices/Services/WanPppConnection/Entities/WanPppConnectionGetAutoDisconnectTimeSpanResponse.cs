namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetAutoDisconnectTimeSpanResponse")]
public sealed record WanPppConnectionGetAutoDisconnectTimeSpanResponse
{
    [MessageBodyMember(Name = "NewX_AVM-DE_DisconnectPreventionEnable")]
    public bool DisconnectPreventionEnable { get; set; }

    [MessageBodyMember(Name = "NewX_AVM-DE_DisconnectPreventionHour")]
    public ushort DisconnectPreventionHour { get; set; }
}