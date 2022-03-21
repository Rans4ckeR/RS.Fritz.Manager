namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetAutoDisconnectTimeSpanResponse")]
public readonly record struct WanPppConnectionGetAutoDisconnectTimeSpanResponse(
    [property: MessageBodyMember(Name = "NewX_AVM-DE_DisconnectPreventionEnable")] bool DisconnectPreventionEnable,
    [property: MessageBodyMember(Name = "NewX_AVM-DE_DisconnectPreventionHour")] ushort DisconnectPreventionHour);