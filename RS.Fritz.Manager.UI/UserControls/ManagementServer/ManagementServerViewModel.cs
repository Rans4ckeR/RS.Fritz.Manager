namespace RS.Fritz.Manager.UI;

internal sealed class ManagementServerViewModel : FritzServiceViewModel
{
    private KeyValuePair<ManagementServerGetInfoResponse?, UPnPFault?>? managementServerGetInfoResponse;
    private KeyValuePair<ManagementServerGetTr069FirmwareDownloadEnabledResponse?, UPnPFault?>? managementServerGetTr069FirmwareDownloadEnabledResponse;

    public ManagementServerViewModel(
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
        : base(deviceLoginInfo, logger, "ManagementServer")
    {
        ManagementServerSetManagementServerUrlViewModel = managementServerSetManagementServerUrlViewModel;
        ManagementServerSetManagementServerUsernameViewModel = managementServerSetManagementServerUsernameViewModel;
        ManagementServerSetManagementServerPasswordViewModel = managementServerSetManagementServerPasswordViewModel;
        ManagementServerSetPeriodicInformViewModel = managementServerSetPeriodicInformViewModel;
        ManagementServerSetConnectionRequestAuthenticationViewModel = managementServerSetConnectionRequestAuthenticationViewModel;
        ManagementServerSetUpgradeManagementViewModel = managementServerSetUpgradeManagementViewModel;
        ManagementServerSetTr069EnableViewModel = managementServerSetTr069EnableViewModel;
        ManagementServerSetTr069FirmwareDownloadEnabledViewModel = managementServerSetTr069FirmwareDownloadEnabledViewModel;
    }

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

    public ManagementServerSetManagementServerUrlViewModel ManagementServerSetManagementServerUrlViewModel { get; }

    public ManagementServerSetManagementServerUsernameViewModel ManagementServerSetManagementServerUsernameViewModel { get; }

    public ManagementServerSetManagementServerPasswordViewModel ManagementServerSetManagementServerPasswordViewModel { get; }

    public ManagementServerSetPeriodicInformViewModel ManagementServerSetPeriodicInformViewModel { get; }

    public ManagementServerSetConnectionRequestAuthenticationViewModel ManagementServerSetConnectionRequestAuthenticationViewModel { get; }

    public ManagementServerSetUpgradeManagementViewModel ManagementServerSetUpgradeManagementViewModel { get; }

    public ManagementServerSetTr069EnableViewModel ManagementServerSetTr069EnableViewModel { get; }

    public ManagementServerSetTr069FirmwareDownloadEnabledViewModel ManagementServerSetTr069FirmwareDownloadEnabledViewModel { get; }

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