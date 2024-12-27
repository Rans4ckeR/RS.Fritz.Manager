namespace RS.Fritz.Manager.UI;

internal abstract class ManualOperationViewModel<TRequest, TResponse>(
    DeviceLoginInfo deviceLoginInfo,
    ILogger logger,
    string title,
    string buttonText,
    Func<InternetGatewayDevice, TRequest, Task<TResponse>> operation)
    : FritzServiceViewModel(deviceLoginInfo, logger)
    where TRequest : struct
    where TResponse : struct
{
    private readonly Func<InternetGatewayDevice, TRequest, Task<TResponse>> operation = operation;

    public string Title { get; } = title;

    public string ButtonText { get; } = buttonText;

    public KeyValuePair<TResponse?, UPnPFault?>? Response
    {
        get;
        private set => _ = SetProperty(ref field, value);
    }

    protected virtual TRequest BuildRequest() => default;

    protected override async ValueTask DoExecuteDefaultCommandAsync(CancellationToken cancellationToken)
        => Response = await ExecuteApiAsync(operation, BuildRequest()).ConfigureAwait(true);
}