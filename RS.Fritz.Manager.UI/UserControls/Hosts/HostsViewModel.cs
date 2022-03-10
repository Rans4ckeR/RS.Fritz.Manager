namespace RS.Fritz.Manager.UI;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Logging;
using RS.Fritz.Manager.API;

internal sealed class HostsViewModel : FritzServiceViewModel
{
    private readonly IDeviceHostsService deviceHostsService;

    private HostsGetHostNumberOfEntriesResponse? hostsGetHostNumberOfEntriesResponse;
    private DeviceHostInfo? deviceHostInfo;
    private HostsGetGenericHostEntryResponse? hostsGetGenericHostEntryResponse;
    private ushort? getHostsGetGenericHostEntryIndex;
    private bool getHostsGetGenericHostEntryCommandActive;
    private bool canExecuteGetHostsGetGenericHostEntryCommand;

    public HostsViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger, IDeviceHostsService deviceHostsService)
        : base(deviceLoginInfo, logger)
    {
        this.deviceHostsService = deviceHostsService;
        GetHostsGetGenericHostEntryCommand = new AsyncRelayCommand<bool?>(ExecuteGetHostsGetGenericHostEntryCommandAsync, _ => CanExecuteGetHostsGetGenericHostEntryCommand);
    }

    public HostsGetHostNumberOfEntriesResponse? HostsGetHostNumberOfEntriesResponse
    {
        get => hostsGetHostNumberOfEntriesResponse;
        private set { _ = SetProperty(ref hostsGetHostNumberOfEntriesResponse, value); }
    }

    public DeviceHostInfo? DeviceHostInfo
    {
        get => deviceHostInfo;
        private set { _ = SetProperty(ref deviceHostInfo, value); }
    }

    public HostsGetGenericHostEntryResponse? HostsGetGenericHostEntryResponse
    {
        get => hostsGetGenericHostEntryResponse;
        private set { _ = SetProperty(ref hostsGetGenericHostEntryResponse, value); }
    }

    public IAsyncRelayCommand GetHostsGetGenericHostEntryCommand { get; }

    public ushort? GetHostsGetGenericHostEntryIndex
    {
        get => getHostsGetGenericHostEntryIndex;
        set
        {
            if (SetProperty(ref getHostsGetGenericHostEntryIndex, value))
                GetHostsGetGenericHostEntryCommand.NotifyCanExecuteChanged();
        }
    }

    private bool CanExecuteGetHostsGetGenericHostEntryCommand
    {
        get => canExecuteGetHostsGetGenericHostEntryCommand;
        set
        {
            if (SetProperty(ref canExecuteGetHostsGetGenericHostEntryCommand, value))
                GetHostsGetGenericHostEntryCommand.NotifyCanExecuteChanged();
        }
    }

    private bool GetHostsGetGenericHostEntryCommandActive
    {
        get => getHostsGetGenericHostEntryCommandActive;
        set
        {
            if (SetProperty(ref getHostsGetGenericHostEntryCommandActive, value))
                GetHostsGetGenericHostEntryCommand.NotifyCanExecuteChanged();
        }
    }

    protected override async Task DoExecuteDefaultCommandAsync()
    {
        await API.TaskExtensions.WhenAllSafe(new[]
            {
                GetHostsGetHostListPathAsync(),
                GetHostsGetHostNumberOfEntriesAsync()
            });
    }

    protected override void FritzServiceViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        base.FritzServiceViewModelPropertyChanged(sender, e);

        switch (e.PropertyName)
        {
            case nameof(GetHostsGetGenericHostEntryIndex):
                {
                    UpdateCanExecuteGetHostsGetGenericHostEntryCommand();
                    break;
                }
        }
    }

    private async Task ExecuteGetHostsGetGenericHostEntryCommandAsync(bool? arg)
    {
        try
        {
            GetHostsGetGenericHostEntryCommandActive = true;

            await DoExecuteGetHostsGetGenericHostEntryCommandAsync();
        }
        finally
        {
            GetHostsGetGenericHostEntryCommandActive = false;
        }
    }

    private void UpdateCanExecuteGetHostsGetGenericHostEntryCommand()
    {
        CanExecuteGetHostsGetGenericHostEntryCommand = GetCanExecuteGetHostsGetGenericHostEntryCommand();
    }

    private bool GetCanExecuteGetHostsGetGenericHostEntryCommand()
    {
        return GetHostsGetGenericHostEntryIndex >= 0 && GetHostsGetGenericHostEntryIndex < HostsGetHostNumberOfEntriesResponse!.HostNumberOfEntries && !GetHostsGetGenericHostEntryCommandActive;
    }

    private async Task GetHostsGetHostNumberOfEntriesAsync()
    {
        HostsGetHostNumberOfEntriesResponse = await DeviceLoginInfo.InternetGatewayDevice!.ExecuteAsync((h, d) => h.GetHostsGetHostNumberOfEntriesAsync(d));
    }

    private async Task DoExecuteGetHostsGetGenericHostEntryCommandAsync()
    {
        HostsGetGenericHostEntryResponse = await DeviceLoginInfo.InternetGatewayDevice!.ExecuteAsync((h, d) => h.GetHostsGetGenericHostEntryAsync(d, GetHostsGetGenericHostEntryIndex!.Value));
    }

    private async Task GetHostsGetHostListPathAsync()
    {
        HostsGetHostListPathResponse newHostsGetHostListPathResponse = await DeviceLoginInfo.InternetGatewayDevice!.ExecuteAsync((h, d) => h.GetHostsGetHostListPathAsync(d));
        string hostListPath = newHostsGetHostListPathResponse.HostListPath;
        var hostListPathUri = new Uri(FormattableString.Invariant($"https://{DeviceLoginInfo.InternetGatewayDevice.InternetGatewayDevice.PreferredLocation.Host}:{DeviceLoginInfo.InternetGatewayDevice.InternetGatewayDevice.SecurityPort}{hostListPath}"));
        IEnumerable<DeviceHost> deviceHosts = await deviceHostsService.GetDeviceHostsAsync(hostListPathUri);

        DeviceHostInfo = new DeviceHostInfo(hostListPath, hostListPathUri, new ObservableCollection<DeviceHost>(deviceHosts));
    }
}