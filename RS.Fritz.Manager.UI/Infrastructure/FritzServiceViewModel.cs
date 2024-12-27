using System.ServiceModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;

namespace RS.Fritz.Manager.UI;

internal abstract class FritzServiceViewModel : ObservableRecipient
{
    private readonly string? requiredServiceType;

    protected FritzServiceViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger, string? requiredServiceType = null)
        : base(StrongReferenceMessenger.Default)
    {
        IsActive = true;
        Logger = logger;
        DeviceLoginInfo = deviceLoginInfo;
        this.requiredServiceType = requiredServiceType;
        DefaultCommand = new AsyncRelayCommand<bool?>(ExecuteDefaultCommandAsync, _ => CanExecuteDefaultCommand);

        StrongReferenceMessenger.Default.Register<PropertyChangedMessage<bool>>(this, static (r, m) => ((FritzServiceViewModel)r).Receive(m));
    }

    public DeviceLoginInfo DeviceLoginInfo { get; }

    public IAsyncRelayCommand DefaultCommand { get; }

    public bool DefaultCommandActive
    {
        get;
        set
        {
            if (SetProperty(ref field, value, true))
                DefaultCommand.NotifyCanExecuteChanged();
        }
    }

    protected InternetGatewayDevice ApiDevice => DeviceLoginInfo.SelectedInternetGatewayDevice!;

    protected ILogger Logger { get; }

    protected bool CanExecuteDefaultCommand
    {
        get;
        private set
        {
            if (SetProperty(ref field, value))
                DefaultCommand.NotifyCanExecuteChanged();
        }
    }

    protected abstract ValueTask DoExecuteDefaultCommandAsync(CancellationToken cancellationToken);

    protected virtual void Receive(PropertyChangedMessage<bool> message)
    {
        if (message.Sender is FritzServiceViewModel)
        {
            switch (message.PropertyName)
            {
                case nameof(DefaultCommandActive):
                    {
                        UpdateCanExecuteDefaultCommand();
                        break;
                    }
            }
        }
        else if (message.Sender == DeviceLoginInfo)
        {
            switch (message.PropertyName)
            {
                case nameof(DeviceLoginInfo.LoginInfoSet):
                case nameof(DeviceLoginInfo.Authenticated):
                    {
                        UpdateCanExecuteDefaultCommand();
                        break;
                    }
            }
        }
    }

    protected virtual bool GetCanExecuteDefaultCommand()
        => DeviceLoginInfo.Authenticated && !DefaultCommandActive && (requiredServiceType is null || ApiDevice.Services.Any(r => r.ServiceType.Contains(FormattableString.Invariant($":{requiredServiceType}:"), StringComparison.OrdinalIgnoreCase)));

    protected void UpdateCanExecuteDefaultCommand()
        => CanExecuteDefaultCommand = GetCanExecuteDefaultCommand();

    protected void UpdateAndNotifyCanExecuteDefaultCommand()
    {
        UpdateCanExecuteDefaultCommand();
        DefaultCommand.NotifyCanExecuteChanged();
    }

    protected Task<KeyValuePair<T?, UPnPFault?>> ExecuteApiAsync<T>(Func<InternetGatewayDevice, Task<T>> operation, IDictionary<ushort, string>? errorReasons = null)
        where T : struct
        => DoExecuteApiAsync(operation(ApiDevice), errorReasons);

    protected Task<KeyValuePair<T?, UPnPFault?>> ExecuteApiAsync<T>(Func<InternetGatewayDevice, int, Task<T>> operation, int interfaceNumber, IDictionary<ushort, string>? errorReasons = null)
        where T : struct
        => DoExecuteApiAsync(operation(ApiDevice, interfaceNumber), errorReasons);

    protected Task<KeyValuePair<TResponse?, UPnPFault?>> ExecuteApiAsync<TRequest, TResponse>(Func<InternetGatewayDevice, TRequest, Task<TResponse>> operation, TRequest request, IDictionary<ushort, string>? errorReasons = null)
        where TRequest : struct
        where TResponse : struct
        => DoExecuteApiAsync(operation(ApiDevice, request), errorReasons);

    private static async Task<KeyValuePair<T?, UPnPFault?>> DoExecuteApiAsync<T>(Task<T> operation, IDictionary<ushort, string>? errorReasons)
        where T : struct
    {
        UPnPFault error;

        try
        {
            return new(await operation.ConfigureAwait(true), null);
        }
        catch (FaultException<API.UPnPFault> ex)
        {
            error = new(ex.Detail.ErrorCode, ex.Detail.ErrorDescription);
        }
        catch (FaultException<AvmUPnPFault> ex)
        {
            error = new(ex.Detail.ErrorCode, ex.Detail.ErrorDescription);
        }

        if (errorReasons?.TryGetValue(error.ErrorCode, out string? errorReason) ?? false)
            error.ErrorReason = errorReason;

        return new(null, error);
    }

    private async Task ExecuteDefaultCommandAsync(bool? showView, CancellationToken cancellationToken)
    {
        try
        {
            DefaultCommandActive = true;

            await DoExecuteDefaultCommandAsync(cancellationToken).ConfigureAwait(true);

            if (showView ?? true)
                _ = StrongReferenceMessenger.Default.Send(new ActiveViewValueChangedMessage(this));
        }
        catch (OperationCanceledException)
        {
            // Ignore Task cancellation
        }
        catch (Exception ex)
        {
            Logger.ExceptionThrown(ex);
        }
        finally
        {
            DefaultCommandActive = false;
        }
    }
}