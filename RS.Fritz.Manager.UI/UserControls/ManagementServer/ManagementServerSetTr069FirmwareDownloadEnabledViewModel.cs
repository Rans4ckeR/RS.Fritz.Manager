namespace RS.Fritz.Manager.UI;

internal sealed class ManagementServerSetTr069FirmwareDownloadEnabledViewModel(DeviceLoginInfo deviceLoginInfo, ILogger<ManagementServerSetTr069FirmwareDownloadEnabledViewModel> logger)
    : ManualOperationViewModel<ManagementServerSetTr069FirmwareDownloadEnabledRequest, ManagementServerSetTr069FirmwareDownloadEnabledResponse>(deviceLoginInfo, logger, "SetTr069FirmwareDownloadEnabled", "Update Tr069FirmwareDownloadEnabled", static (d, r) => d.ManagementServerSetTr069FirmwareDownloadEnabledAsync(r))
{
    public bool? Tr069FirmwareDownloadEnabled
    {
        get;
        set
        {
            if (SetProperty(ref field, value))
                UpdateAndNotifyCanExecuteDefaultCommand();
        }
    }

    protected override ManagementServerSetTr069FirmwareDownloadEnabledRequest BuildRequest()
        => new(Tr069FirmwareDownloadEnabled!.Value);

    protected override bool GetCanExecuteDefaultCommand()
        => base.GetCanExecuteDefaultCommand() && Tr069FirmwareDownloadEnabled.HasValue;
}