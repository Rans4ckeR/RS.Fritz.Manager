﻿namespace RS.Fritz.Manager.UI;

using Microsoft.Extensions.DependencyInjection;

internal static class ServiceCollectionExtensions
{
    public static IServiceCollection AddViewModels(this IServiceCollection serviceCollection) =>
        serviceCollection.AddSingleton<MainWindowViewModel>()
            .AddSingleton<DeviceInfoViewModel>()
            .AddSingleton<DeviceInfoSetProvisioningCodeViewModel>()
            .AddSingleton<LanConfigSecurityViewModel>()
            .AddSingleton<LanConfigSecuritySetConfigPasswordViewModel>()
            .AddSingleton<WanDslInterfaceConfigViewModel>()
            .AddSingleton<WanDslInterfaceConfigInfoViewModel>()
            .AddSingleton<WanDslInterfaceConfigDslInfoViewModel>()
            .AddSingleton<WanDslLinkConfigViewModel>()
            .AddSingleton<WanCommonInterfaceConfigViewModel>()
            .AddSingleton<WanCommonInterfaceConfigSetWanAccessTypeViewModel>()
            .AddSingleton<WanCommonInterfaceConfigGetOnlineMonitorViewModel>()
            .AddSingleton<HostsViewModel>()
            .AddSingleton<HostsGetGenericHostEntryViewModel>()
            .AddSingleton<HostsHostsCheckUpdateViewModel>()
            .AddSingleton<Layer3ForwardingViewModel>()
            .AddSingleton<Layer3ForwardingGetGenericForwardingEntryViewModel>()
            .AddSingleton<WanPppConnectionViewModel>()
            .AddSingleton<WanIpConnectionViewModel>()
            .AddSingleton<WanEthernetLinkConfigViewModel>()
            .AddSingleton<AvmSpeedtestViewModel>()
            .AddSingleton<CaptureControlCaptureViewModel>()
            .AddSingleton<WanIpConnectionGetGenericPortMappingEntryViewModel>()
            .AddSingleton<WanPppConnectionGetGenericPortMappingEntryViewModel>()
            .AddSingleton<LanEthernetInterfaceConfigViewModel>()
            .AddSingleton<LanHostConfigManagementViewModel>()
            .AddSingleton<WlanConfigurationViewModel>()
            .AddSingleton<ManagementServerViewModel>()
            .AddSingleton<ManagementServerSetManagementServerUrlViewModel>()
            .AddSingleton<ManagementServerSetManagementServerUsernameViewModel>()
            .AddSingleton<ManagementServerSetManagementServerPasswordViewModel>()
            .AddSingleton<ManagementServerSetPeriodicInformViewModel>()
            .AddSingleton<ManagementServerSetConnectionRequestAuthenticationViewModel>()
            .AddSingleton<ManagementServerSetUpgradeManagementViewModel>()
            .AddSingleton<ManagementServerSetTr069EnableViewModel>()
            .AddSingleton<ManagementServerSetTr069FirmwareDownloadEnabledViewModel>()
            .AddSingleton<TimeViewModel>()
            .AddSingleton<TimeSetNtpServersViewModel>()
            .AddSingleton<UserInterfaceViewModel>()
            .AddSingleton<UserInterfaceCheckUpdateViewModel>()
            .AddSingleton<UserInterfaceDoPrepareCgiViewModel>()
            .AddSingleton<UserInterfaceDoUpdateViewModel>()
            .AddSingleton<UserInterfaceDoManualUpdateViewModel>()
            .AddSingleton<UserInterfaceSetInternationalConfigViewModel>()
            .AddSingleton<UserInterfaceSetConfigViewModel>()
            .AddSingleton<DeviceConfigViewModel>()
            .AddSingleton<DeviceConfigGenerateUuIdViewModel>()
            .AddSingleton<DeviceConfigCreateUrlSidViewModel>();
}