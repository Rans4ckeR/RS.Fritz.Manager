namespace RS.Fritz.Manager.UI;

internal sealed class ManagementServerViewModel : FritzServiceViewModel
{
    private KeyValuePair<ManagementServerGetInfoResponse?, UPnPFault?>? managementServerGetInfoResponse;
    private KeyValuePair<ManagementServerGetTr069FirmwareDownloadEnabledResponse?, UPnPFault?>? managementServerGetTr069FirmwareDownloadEnabledResponse;

    public ManagementServerViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger)
        : base(deviceLoginInfo, logger, "ManagementServer")
    {
    }

    public KeyValuePair<ManagementServerGetInfoResponse?, UPnPFault?>? ManagementServerGetInfoResponse
    {
        get => managementServerGetInfoResponse;
        private set { _ = SetProperty(ref managementServerGetInfoResponse, value); }
    }

    public KeyValuePair<ManagementServerGetTr069FirmwareDownloadEnabledResponse?, UPnPFault?>? ManagementServerGetTr069FirmwareDownloadEnabledResponse
    {
        get => managementServerGetTr069FirmwareDownloadEnabledResponse;
        private set { _ = SetProperty(ref managementServerGetTr069FirmwareDownloadEnabledResponse, value); }
    }

    protected override async Task DoExecuteDefaultCommandAsync(CancellationToken cancellationToken)
    {
        await API.TaskExtensions.WhenAllSafe(new[]
            {
               GetManagementServerGetInfoAsync(),
               GetManagementServerGetTr069FirmwareDownloadEnabledAsync()
            });
    }

    private async Task GetManagementServerGetInfoAsync()
    {
        ManagementServerGetInfoResponse = await ExecuteApiAsync(q => q.ManagementServerGetInfoAsync());
    }

    private async Task GetManagementServerGetTr069FirmwareDownloadEnabledAsync()
    {
        ManagementServerGetTr069FirmwareDownloadEnabledResponse = await ExecuteApiAsync(q => q.ManagementServerGetTr069FirmwareDownloadEnabledAsync());
    }
}