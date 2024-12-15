namespace RS.Fritz.Manager.UI;

internal sealed class ManagementServerSetManagementServerUrlViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger)
    : ManualOperationViewModel<ManagementServerSetManagementServerUrlRequest, ManagementServerSetManagementServerUrlResponse>(deviceLoginInfo, logger, "SetManagementServerUrl", "Update ManagementServerUrl", (d, r) => d.ManagementServerSetManagementServerUrlAsync(r))
{
    public string? Url
    {
        get;
        set
        {
            if (SetProperty(ref field, value))
                UpdateAndNotifyCanExecuteDefaultCommand();
        }
    }

    protected override ManagementServerSetManagementServerUrlRequest BuildRequest()
        => new(Url!);
}