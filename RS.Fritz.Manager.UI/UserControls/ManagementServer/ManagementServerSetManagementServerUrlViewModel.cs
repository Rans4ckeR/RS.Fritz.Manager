namespace RS.Fritz.Manager.UI;

internal sealed class ManagementServerSetManagementServerUrlViewModel(DeviceLoginInfo deviceLoginInfo, ILogger<ManagementServerSetManagementServerUrlViewModel> logger)
    : ManualOperationViewModel<ManagementServerSetManagementServerUrlRequest, ManagementServerSetManagementServerUrlResponse>(deviceLoginInfo, logger, "SetManagementServerUrl", "Update ManagementServerUrl", static (d, r) => d.ManagementServerSetManagementServerUrlAsync(r))
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