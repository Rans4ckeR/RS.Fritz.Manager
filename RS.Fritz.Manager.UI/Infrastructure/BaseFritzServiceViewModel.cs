namespace RS.Fritz.Manager.UI;

using System.ComponentModel;
using System.ServiceModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

internal abstract class BaseFritzServiceViewModel : ObservableRecipient
{
    private readonly string? requiredServiceType;

    private bool defaultCommandActive;
    private bool canExecuteDefaultCommand;

    protected BaseFritzServiceViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger, string? requiredServiceType = null)
    {
        Logger = logger;
        DeviceLoginInfo = deviceLoginInfo;
        this.requiredServiceType = requiredServiceType;
        DefaultCommand = new AsyncRelayCommand<bool?>(ExecuteDefaultCommandAsync, _ => CanExecuteDefaultCommand);
        PropertyChanged += FritzServiceViewModelPropertyChanged;
        IsActive = true;
    }

    public DeviceLoginInfo DeviceLoginInfo { get; }

    public IAsyncRelayCommand DefaultCommand { get; }

    public bool DefaultCommandActive
    {
        get => defaultCommandActive;
        set
        {
            if (SetProperty(ref defaultCommandActive, value))
                DefaultCommand.NotifyCanExecuteChanged();
        }
    }

    protected InternetGatewayDevice ApiDevice => DeviceLoginInfo.InternetGatewayDevice!.ApiDevice;

    protected ILogger Logger { get; }

    protected bool CanExecuteDefaultCommand
    {
        get => canExecuteDefaultCommand;
        private set
        {
            if (SetProperty(ref canExecuteDefaultCommand, value))
                DefaultCommand.NotifyCanExecuteChanged();
        }
    }

    protected abstract Task DoExecuteDefaultCommandAsync(CancellationToken cancellationToken);

    protected virtual void FritzServiceViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        switch (e.PropertyName)
        {
            case nameof(DefaultCommandActive):
                {
                    UpdateCanExecuteDefaultCommand();
                    break;
                }
        }
    }

    protected virtual bool GetCanExecuteDefaultCommand()
    {
        return (DeviceLoginInfo.InternetGatewayDevice?.Authenticated ?? false) && !DefaultCommandActive && (requiredServiceType is null || ApiDevice.Services.Any(r => r.ServiceType.StartsWith(FormattableString.Invariant($"urn:dslforum-org:service:{requiredServiceType}:"), StringComparison.OrdinalIgnoreCase)));
    }

    protected void UpdateCanExecuteDefaultCommand()
    {
        CanExecuteDefaultCommand = GetCanExecuteDefaultCommand();
    }

    protected Task<KeyValuePair<T?, UPnPFault?>> ExecuteApiAsync<T>(Func<InternetGatewayDevice, Task<T>> operation, IDictionary<ushort, string>? errorReasons = null)
        where T : struct
    {
        return DoExecuteApiAsync(operation(ApiDevice), errorReasons);
    }

    protected Task<KeyValuePair<T?, UPnPFault?>> ExecuteApiAsync<T>(Func<InternetGatewayDevice, int, Task<T>> operation, int interfaceNumber, IDictionary<ushort, string>? errorReasons = null)
        where T : struct
    {
        return DoExecuteApiAsync(operation(ApiDevice, interfaceNumber), errorReasons);
    }

    protected Task<KeyValuePair<TResponse?, UPnPFault?>> ExecuteApiAsync<TRequest, TResponse>(Func<InternetGatewayDevice, TRequest, Task<TResponse>> operation, TRequest request, IDictionary<ushort, string>? errorReasons = null)
        where TRequest : struct
        where TResponse : struct
    {
        return DoExecuteApiAsync(operation(ApiDevice, request), errorReasons);
    }

    private static async Task<KeyValuePair<T?, UPnPFault?>> DoExecuteApiAsync<T>(Task<T> operation, IDictionary<ushort, string>? errorReasons)
        where T : struct
    {
        UPnPFault error;

        try
        {
            return new KeyValuePair<T?, UPnPFault?>(await operation, null);
        }
        catch (FaultException<UPnPFault1> ex)
        {
            error = new UPnPFault(ex.Detail.ErrorCode, ex.Detail.ErrorDescription);
        }
        catch (FaultException<UPnPFault2> ex)
        {
            error = new UPnPFault(ex.Detail.ErrorCode, ex.Detail.ErrorDescription);
        }

        if (errorReasons?.TryGetValue(error.ErrorCode, out string? errorReason) ?? false)
            error.ErrorReason = errorReason;

        return new KeyValuePair<T?, UPnPFault?>(null, error);
    }

    private async Task ExecuteDefaultCommandAsync(bool? showView, CancellationToken cancellationToken)
    {
        try
        {
            DefaultCommandActive = true;

            await DoExecuteDefaultCommandAsync(cancellationToken);

            if (showView ?? true)
                _ = WeakReferenceMessenger.Default.Send(new ActiveViewValueChangedMessage(this));
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