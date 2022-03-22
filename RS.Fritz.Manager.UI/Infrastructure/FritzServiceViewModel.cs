namespace RS.Fritz.Manager.UI;

using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;

internal abstract class FritzServiceViewModel : ObservableRecipient, IRecipient<PropertyChangedMessage<bool>>
{
    private bool defaultCommandActive;
    private bool canExecuteDefaultCommand;

    protected FritzServiceViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger)
    {
        Logger = logger;
        DeviceLoginInfo = deviceLoginInfo;
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

    public virtual void Receive(PropertyChangedMessage<bool> message)
    {
        if (message.Sender == DeviceLoginInfo)
        {
            switch (message.PropertyName)
            {
                case nameof(DeviceLoginInfo.LoginInfoSet):
                    {
                        UpdateCanExecuteDefaultCommand();
                        break;
                    }
            }
        }
        else if (message.Sender == DeviceLoginInfo.InternetGatewayDevice)
        {
            switch (message.PropertyName)
            {
                case nameof(DeviceLoginInfo.InternetGatewayDevice.Authenticated):
                    {
                        UpdateCanExecuteDefaultCommand();
                        break;
                    }
            }
        }
    }

    protected abstract Task DoExecuteDefaultCommandAsync(CancellationToken cancellationToken = default);

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
        return (DeviceLoginInfo.InternetGatewayDevice?.Authenticated ?? false) && !DefaultCommandActive;
    }

    protected void UpdateCanExecuteDefaultCommand()
    {
        CanExecuteDefaultCommand = GetCanExecuteDefaultCommand();
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