namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetChannelInfoResponse")]
public readonly record struct WlanConfigurationGetChannelInfoResponse(
    [property: MessageBodyMember(Name = "NewChannel")] byte Channel,
    [property: MessageBodyMember(Name = "NewPossibleChannels")] string PossibleChannels);