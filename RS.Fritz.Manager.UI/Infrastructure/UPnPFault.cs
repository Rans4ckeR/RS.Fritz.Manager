namespace RS.Fritz.Manager.UI;

public sealed record UPnPFault(ushort ErrorCode, string ErrorDescription)
{
    public string? ErrorReason { get; set; }
}