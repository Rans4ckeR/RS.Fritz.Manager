namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "SetNtpServers")]
public readonly record struct TimeSetNtpServersRequest(
    [property: MessageBodyMember(Name = "NewNTPServer1")] string NtpServer1,
    [property: MessageBodyMember(Name = "NewNTPServer2")] string NtpServer2);