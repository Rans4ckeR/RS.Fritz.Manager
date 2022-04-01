namespace RS.Fritz.Manager.UI;

internal sealed class Layer3ForwardingViewModel : FritzServiceViewModel
{
    private KeyValuePair<Layer3ForwardingGetDefaultConnectionServiceResponse?, UPnPFault?>? layer3ForwardingGetDefaultConnectionServiceResponse;
    private KeyValuePair<Layer3ForwardingGetForwardNumberOfEntriesResponse?, UPnPFault?>? layer3ForwardingGetForwardNumberOfEntriesResponse;

    public Layer3ForwardingViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger, Layer3ForwardingGetGenericForwardingEntryViewModel layer3ForwardingGetGenericForwardingEntryViewModel)
        : base(deviceLoginInfo, logger, "Layer3Forwarding")
    {
        Layer3ForwardingGetGenericForwardingEntryViewModel = layer3ForwardingGetGenericForwardingEntryViewModel;
    }

    public Layer3ForwardingGetGenericForwardingEntryViewModel Layer3ForwardingGetGenericForwardingEntryViewModel { get; }

    public KeyValuePair<Layer3ForwardingGetDefaultConnectionServiceResponse?, UPnPFault?>? Layer3ForwardingGetDefaultConnectionServiceResponse
    {
        get => layer3ForwardingGetDefaultConnectionServiceResponse;
        private set { _ = SetProperty(ref layer3ForwardingGetDefaultConnectionServiceResponse, value); }
    }

    public KeyValuePair<Layer3ForwardingGetForwardNumberOfEntriesResponse?, UPnPFault?>? Layer3ForwardingGetForwardNumberOfEntriesResponse
    {
        get => layer3ForwardingGetForwardNumberOfEntriesResponse;
        private set
        {
            if (SetProperty(ref layer3ForwardingGetForwardNumberOfEntriesResponse, value))
                Layer3ForwardingGetGenericForwardingEntryViewModel.ForwardNumberOfEntries = Layer3ForwardingGetForwardNumberOfEntriesResponse?.Key?.ForwardNumberOfEntries;
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
        Layer3ForwardingGetDefaultConnectionServiceResponse = await ExecuteApiAsync(q => q.Layer3ForwardingGetDefaultConnectionServiceAsync());
    }

    private async Task GetLayer3ForwardingGetForwardNumberOfEntriesResponseAsync()
    {
        Layer3ForwardingGetForwardNumberOfEntriesResponse = await ExecuteApiAsync(q => q.Layer3ForwardingGetForwardNumberOfEntriesAsync());
    }
}