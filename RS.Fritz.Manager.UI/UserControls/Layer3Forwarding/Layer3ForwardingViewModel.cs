namespace RS.Fritz.Manager.UI;

internal sealed class Layer3ForwardingViewModel : FritzServiceViewModel
{
    private Layer3ForwardingGetDefaultConnectionServiceResponse? layer3ForwardingGetDefaultConnectionServiceResponse;
    private Layer3ForwardingGetForwardNumberOfEntriesResponse? layer3ForwardingGetForwardNumberOfEntriesResponse;

    public Layer3ForwardingViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger, Layer3ForwardingGetGenericForwardingEntryViewModel layer3ForwardingGetGenericForwardingEntryViewModel)
        : base(deviceLoginInfo, logger, "Layer3Forwarding")
    {
        Layer3ForwardingGetGenericForwardingEntryViewModel = layer3ForwardingGetGenericForwardingEntryViewModel;
    }

    public Layer3ForwardingGetGenericForwardingEntryViewModel Layer3ForwardingGetGenericForwardingEntryViewModel { get; }

    public Layer3ForwardingGetDefaultConnectionServiceResponse? Layer3ForwardingGetDefaultConnectionServiceResponse
    {
        get => layer3ForwardingGetDefaultConnectionServiceResponse;
        private set { _ = SetProperty(ref layer3ForwardingGetDefaultConnectionServiceResponse, value); }
    }

    public Layer3ForwardingGetForwardNumberOfEntriesResponse? Layer3ForwardingGetForwardNumberOfEntriesResponse
    {
        get => layer3ForwardingGetForwardNumberOfEntriesResponse;
        private set
        {
            if (SetProperty(ref layer3ForwardingGetForwardNumberOfEntriesResponse, value))
                Layer3ForwardingGetGenericForwardingEntryViewModel.ForwardNumberOfEntries = Layer3ForwardingGetForwardNumberOfEntriesResponse?.ForwardNumberOfEntries;
        }
    }

    protected override async Task DoExecuteDefaultCommandAsync(CancellationToken cancellationToken)
    {
        await API.TaskExtensions.WhenAllSafe(new[]
            {
                GetLayer3ForwardingGetDefaultConnectionServiceAsync(),
                GetLayer3ForwardingGetForwardNumberOfEntriesResponseAsync()
            });
    }

    private async Task GetLayer3ForwardingGetDefaultConnectionServiceAsync()
    {
        Layer3ForwardingGetDefaultConnectionServiceResponse = await DeviceLoginInfo.InternetGatewayDevice!.ApiDevice.Layer3ForwardingGetDefaultConnectionServiceAsync();
    }

    private async Task GetLayer3ForwardingGetForwardNumberOfEntriesResponseAsync()
    {
        Layer3ForwardingGetForwardNumberOfEntriesResponse = await DeviceLoginInfo.InternetGatewayDevice!.ApiDevice.Layer3ForwardingGetForwardNumberOfEntriesAsync();
    }
}