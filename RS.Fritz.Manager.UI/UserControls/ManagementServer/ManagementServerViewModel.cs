namespace RS.Fritz.Manager.UI;

internal sealed class ManagementServerViewModel(
    DeviceLoginInfo deviceLoginInfo,
    ILogger logger,
    ManagementServerSetManagementServerUrlViewModel managementServerSetManagementServerUrlViewModel,
    ManagementServerSetManagementServerUsernameViewModel managementServerSetManagementServerUsernameViewModel,
    ManagementServerSetManagementServerPasswordViewModel managementServerSetManagementServerPasswordViewModel,
    ManagementServerSetPeriodicInformViewModel managementServerSetPeriodicInformViewModel,
    ManagementServerSetConnectionRequestAuthenticationViewModel managementServerSetConnectionRequestAuthenticationViewModel,
    ManagementServerSetUpgradeManagementViewModel managementServerSetUpgradeManagementViewModel,
    ManagementServerSetTr069EnableViewModel managementServerSetTr069EnableViewModel,
    ManagementServerSetTr069FirmwareDownloadEnabledViewModel managementServerSetTr069FirmwareDownloadEnabledViewModel)
    : FritzServiceViewModel(deviceLoginInfo, logger, "ManagementServer")
{
    private KeyValuePair<ManagementServerGetInfoResponse?, UPnPFault?>? managementServerGetInfoResponse;
    private KeyValuePair<ManagementServerGetTr069FirmwareDownloadEnabledResponse?, UPnPFault?>? managementServerGetTr069FirmwareDownloadEnabledResponse;

    public KeyValuePair<ManagementServerGetInfoResponse?, UPnPFault?>? ManagementServerGetInfoResponse
    {
        get => managementServerGetInfoResponse;
        private set => _ = SetProperty(ref managementServerGetInfoResponse, value);
    }

    public KeyValuePair<ManagementServerGetTr069FirmwareDownloadEnabledResponse?, UPnPFault?>? ManagementServerGetTr069FirmwareDownloadEnabledResponse
    {
        get => managementServerGetTr069FirmwareDownloadEnabledResponse;
        private set => _ = SetProperty(ref managementServerGetTr069FirmwareDownloadEnabledResponse, value);
    }

    public ManagementServerSetManagementServerUrlViewModel ManagementServerSetManagementServerUrlViewModel { get; } = managementServerSetManagementServerUrlViewModel;

    public ManagementServerSetManagementServerUsernameViewModel ManagementServerSetManagementServerUsernameViewModel { get; } = managementServerSetManagementServerUsernameViewModel;

    public ManagementServerSetManagementServerPasswordViewModel ManagementServerSetManagementServerPasswordViewModel { get; } = managementServerSetManagementServerPasswordViewModel;

    public ManagementServerSetPeriodicInformViewModel ManagementServerSetPeriodicInformViewModel { get; } = managementServerSetPeriodicInformViewModel;

    public ManagementServerSetConnectionRequestAuthenticationViewModel ManagementServerSetConnectionRequestAuthenticationViewModel { get; } = managementServerSetConnectionRequestAuthenticationViewModel;

    public ManagementServerSetUpgradeManagementViewModel ManagementServerSetUpgradeManagementViewModel { get; } = managementServerSetUpgradeManagementViewModel;

    public ManagementServerSetTr069EnableViewModel ManagementServerSetTr069EnableViewModel { get; } = managementServerSetTr069EnableViewModel;

    public ManagementServerSetTr069FirmwareDownloadEnabledViewModel ManagementServerSetTr069FirmwareDownloadEnabledViewModel { get; } = managementServerSetTr069FirmwareDownloadEnabledViewModel;

    protected override ValueTask DoExecuteDefaultCommandAsync(CancellationToken cancellationToken)
    {
        return API.TaskExtensions.WhenAllSafe(
            new[]
            {
               GetManagementServerGetInfoAsync(),
               GetManagementServerGetTr069FirmwareDownloadEnabledAsync()
            },
            true);
    }

    private async Task GetManagementServerGetInfoAsync()
        => ManagementServerGetInfoResponse = await ExecuteApiAsync(q => q.ManagementServerGetInfoAsync()).ConfigureAwait(true);

    private async Task GetManagementServerGetTr069FirmwareDownloadEnabledAsync()
        => ManagementServerGetTr069FirmwareDownloadEnabledResponse = await ExecuteApiAsync(q => q.ManagementServerGetTr069FirmwareDownloadEnabledAsync()).ConfigureAwait(true);
}