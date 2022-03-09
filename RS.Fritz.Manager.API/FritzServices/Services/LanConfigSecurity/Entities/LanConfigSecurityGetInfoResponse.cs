namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetInfoResponse")]
public sealed record LanConfigSecurityGetInfoResponse
{
    [MessageBodyMember(Name = "NewMaxCharsPassword")]
    public ushort MaxCharsPassword { get; set; }

    [MessageBodyMember(Name = "NewMinCharsPassword")]
    public ushort MinCharsPassword { get; set; }

    [MessageBodyMember(Name = "NewAllowedCharsPassword")]
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public string AllowedCharsPassword { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
}