namespace RS.Fritz.Manager.UI;

using System.Collections.ObjectModel;

internal sealed class Layer3ForwardingViewModel : FritzServiceViewModel
{
    private KeyValuePair<Layer3ForwardingGetDefaultConnectionServiceResponse?, UPnPFault?>? layer3ForwardingGetDefaultConnectionServiceResponse;
    private KeyValuePair<Layer3ForwardingGetForwardNumberOfEntriesResponse?, UPnPFault?>? layer3ForwardingGetForwardNumberOfEntriesResponse;
    private ObservableCollection<Layer3ForwardingGetGenericForwardingEntryResponse>? layer3ForwardingGetGenericForwardingEntryResponses;

    public Layer3ForwardingViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger, Layer3ForwardingGetGenericForwardingEntryViewModel layer3ForwardingGetGenericForwardingEntryViewModel)
        : base(deviceLoginInfo, logger, "Layer3Forwarding")
    {
        Layer3ForwardingGetGenericForwardingEntryViewModel = layer3ForwardingGetGenericForwardingEntryViewModel;
    }

    public Layer3ForwardingGetGenericForwardingEntryViewModel Layer3ForwardingGetGenericForwardingEntryViewModel { get; }

    public KeyValuePair<Layer3ForwardingGetDefaultConnectionServiceResponse?, UPnPFault?>? Layer3ForwardingGetDefaultConnectionServiceResponse
    {
        get => layer3ForwardingGetDefaultConnectionServiceResponse;
        private set => _ = SetProperty(ref layer3ForwardingGetDefaultConnectionServiceResponse, value);
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

    public ObservableCollection<Layer3ForwardingGetGenericForwardingEntryResponse>? Layer3ForwardingGetGenericForwardingEntryResponses
    {
        get => layer3ForwardingGetGenericForwardingEntryResponses;
        private set => _ = SetProperty(ref layer3ForwardingGetGenericForwardingEntryResponses, value);
    }

    protected override ValueTask DoExecuteDefaultCommandAsync(CancellationToken cancellationToken)
    {
        return API.TaskExtensions.WhenAllSafe(
            new[]
            {
                GetLayer3ForwardingGetDefaultConnectionServiceAsync(),
                GetLayer3ForwardingGetForwardNumberOfEntriesResponseAsync()
            },
            true);
    }

    private async Task GetLayer3ForwardingGetDefaultConnectionServiceAsync()
        => Layer3ForwardingGetDefaultConnectionServiceResponse = await ExecuteApiAsync(q => q.Layer3ForwardingGetDefaultConnectionServiceAsync()).ConfigureAwait(true);

    private async Task GetLayer3ForwardingGetForwardNumberOfEntriesResponseAsync()
    {
        Layer3ForwardingGetForwardNumberOfEntriesResponse = await ExecuteApiAsync(q => q.Layer3ForwardingGetForwardNumberOfEntriesAsync()).ConfigureAwait(true);

        ushort numberOfEntries = Layer3ForwardingGetForwardNumberOfEntriesResponse!.Value.Key!.Value.ForwardNumberOfEntries;
        var tasks = new List<Task<KeyValuePair<Layer3ForwardingGetGenericForwardingEntryResponse?, UPnPFault?>>>();

        for (ushort i = 0; i < numberOfEntries; i++)
        {
            ushort capturedIndex = i;

            tasks.Add(ExecuteApiAsync(q => q.Layer3ForwardingGetGenericForwardingEntryAsync(new(capturedIndex))));
        }

        KeyValuePair<Layer3ForwardingGetGenericForwardingEntryResponse?, UPnPFault?>[] responses = await API.TaskExtensions.WhenAllSafe(tasks, true).ConfigureAwait(true);

        Layer3ForwardingGetGenericForwardingEntryResponses = new(responses.Select(q => q.Key!.Value));
    }
}