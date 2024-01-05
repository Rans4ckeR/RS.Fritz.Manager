namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetChannelInfoResponse")]
public readonly record struct WlanConfigurationGetChannelInfoResponse(
    [property: MessageBodyMember(Name = "NewChannel")] byte Channel,
    [property: MessageBodyMember(Name = "NewPossibleChannels")] string PossibleChannels,
    [property: MessageBodyMember(Name = "NewX_AVM-DE_AutoChannelEnabled")] bool AutoChannelEnabled,
    [property: MessageBodyMember(Name = "NewX_AVM-DE_FrequencyBand")] string FrequencyBand);