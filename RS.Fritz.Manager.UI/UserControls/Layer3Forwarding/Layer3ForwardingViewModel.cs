using System.Collections.ObjectModel;

namespace RS.Fritz.Manager.UI;

internal sealed class Layer3ForwardingViewModel(DeviceLoginInfo deviceLoginInfo, ILogger<Layer3ForwardingViewModel> logger, Layer3ForwardingGetGenericForwardingEntryViewModel layer3ForwardingGetGenericForwardingEntryViewModel)
    : FritzServiceViewModel(deviceLoginInfo, logger, "Layer3Forwarding")
{
    public Layer3ForwardingGetGenericForwardingEntryViewModel Layer3ForwardingGetGenericForwardingEntryViewModel { get; } = layer3ForwardingGetGenericForwardingEntryViewModel;

    public KeyValuePair<Layer3ForwardingGetDefaultConnectionServiceResponse?, UPnPFault?>?
        Layer3ForwardingGetDefaultConnectionServiceResponse
    {
        get;
        private set => _ = SetProperty(ref field, value);
    }

    public KeyValuePair<Layer3ForwardingGetForwardNumberOfEntriesResponse?, UPnPFault?>?
        Layer3ForwardingGetForwardNumberOfEntriesResponse
    {
        get;
        private set
        {
            if (SetProperty(ref field, value))
                Layer3ForwardingGetGenericForwardingEntryViewModel.ForwardNumberOfEntries = Layer3ForwardingGetForwardNumberOfEntriesResponse?.Key?.ForwardNumberOfEntries;
        }
    }

    public ObservableCollection<Layer3ForwardingGetGenericForwardingEntryResponse>?
        Layer3ForwardingGetGenericForwardingEntryResponses
    {
        get;
        private set => _ = SetProperty(ref field, value);
    }

    protected override ValueTask DoExecuteDefaultCommandAsync(CancellationToken cancellationToken)
        => Task.WhenAll(GetLayer3ForwardingGetDefaultConnectionServiceAsync(), GetLayer3ForwardingGetForwardNumberOfEntriesResponseAsync()).Evaluate(ConfigureAwaitOptions.ContinueOnCapturedContext);

    private async Task GetLayer3ForwardingGetDefaultConnectionServiceAsync()
        => Layer3ForwardingGetDefaultConnectionServiceResponse = await ExecuteApiAsync(static q => q.Layer3ForwardingGetDefaultConnectionServiceAsync()).ConfigureAwait(true);

    private async Task GetLayer3ForwardingGetForwardNumberOfEntriesResponseAsync()
    {
        Layer3ForwardingGetForwardNumberOfEntriesResponse = await ExecuteApiAsync(static q => q.Layer3ForwardingGetForwardNumberOfEntriesAsync()).ConfigureAwait(true);

        ushort numberOfEntries = Layer3ForwardingGetForwardNumberOfEntriesResponse!.Value.Key!.Value.ForwardNumberOfEntries;
        List<Task<KeyValuePair<Layer3ForwardingGetGenericForwardingEntryResponse?, UPnPFault?>>> tasks = [];

        for (ushort i = 0; i < numberOfEntries; i++)
        {
            ushort capturedIndex = i;

            tasks.Add(ExecuteApiAsync(q => q.Layer3ForwardingGetGenericForwardingEntryAsync(new(capturedIndex))));
        }

        KeyValuePair<Layer3ForwardingGetGenericForwardingEntryResponse?, UPnPFault?>[] responses = await Task.WhenAll(tasks).Evaluate(ConfigureAwaitOptions.ContinueOnCapturedContext);

        Layer3ForwardingGetGenericForwardingEntryResponses = [.. responses.Select(static q => q.Key!.Value)];
    }
}