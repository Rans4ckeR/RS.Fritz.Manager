namespace RS.Fritz.Manager.UI;

internal sealed class ManagementServerSetTr069FirmwareDownloadEnabledViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger)
    : ManualOperationViewModel<ManagementServerSetTr069FirmwareDownloadEnabledRequest, ManagementServerSetTr069FirmwareDownloadEnabledResponse>(deviceLoginInfo, logger, "SetTr069FirmwareDownloadEnabled", "Update Tr069FirmwareDownloadEnabled", (d, r) => d.ManagementServerSetTr069FirmwareDownloadEnabledAsync(r))
{
    private bool? tr069FirmwareDownloadEnabled;

    public bool? Tr069FirmwareDownloadEnabled
    {
        get => tr069FirmwareDownloadEnabled;
        set
        {
            if (SetProperty(ref tr069FirmwareDownloadEnabled, value))
                UpdateAndNotifyCanExecuteDefaultCommand();
        }
    }

    protected override ManagementServerSetTr069FirmwareDownloadEnabledRequest BuildRequest()
        => new(Tr069FirmwareDownloadEnabled!.Value);

    protected override bool GetCanExecuteDefaultCommand()
        => base.GetCanExecuteDefaultCommand() && Tr069FirmwareDownloadEnabled.HasValue;
}