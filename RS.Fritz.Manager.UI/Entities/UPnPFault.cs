namespace RS.Fritz.Manager.UI;

internal sealed record UPnPFault(ushort ErrorCode, string ErrorDescription)
{
    public string? ErrorReason { get; set; }
}