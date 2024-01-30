namespace RS.Fritz.Manager.UI;

internal sealed class ManagementServerSetManagementServerUrlViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger)
    : ManualOperationViewModel<ManagementServerSetManagementServerUrlRequest, ManagementServerSetManagementServerUrlResponse>(deviceLoginInfo, logger, "SetManagementServerUrl", "Update ManagementServerUrl", (d, r) => d.ManagementServerSetManagementServerUrlAsync(r))
{
    private string? url;

    public string? Url
    {
        get => url;
        set
        {
            if (SetProperty(ref url, value))
                UpdateAndNotifyCanExecuteDefaultCommand();
        }
    }

    protected override ManagementServerSetManagementServerUrlRequest BuildRequest()
        => new(Url!);
}