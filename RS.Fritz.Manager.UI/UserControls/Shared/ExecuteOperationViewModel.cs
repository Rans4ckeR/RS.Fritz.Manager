namespace RS.Fritz.Manager.UI;

internal abstract class ExecuteOperationViewModel<TRequest, TResponse> : FritzServiceViewModel
    where TRequest : struct
    where TResponse : struct
{
    private readonly Func<InternetGatewayDevice, TRequest, Task<TResponse>> operation;
    private KeyValuePair<TResponse?, UPnPFault?>? response;

    protected ExecuteOperationViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger, string title, string buttonText, Func<InternetGatewayDevice, TRequest, Task<TResponse>> operation)
        : base(deviceLoginInfo, logger)
    {
        this.operation = operation;
        Title = title;
        ButtonText = buttonText;
    }

    public string Title { get; }

    public string ButtonText { get; }

    public KeyValuePair<TResponse?, UPnPFault?>? Response
    {
        get => response;
        private set { _ = SetProperty(ref response, value); }
    }

    protected virtual TRequest BuildRequest()
    {
        return default;
    }

    protected override async Task DoExecuteDefaultCommandAsync(CancellationToken cancellationToken)
    {
        Response = await ExecuteApiAsync(operation, BuildRequest());
    }
}