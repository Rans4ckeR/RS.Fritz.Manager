namespace RS.Fritz.Manager.UI;

using System.ComponentModel;

internal sealed class WanCommonInterfaceConfigSetWanAccessTypeViewModel : FritzServiceViewModel
{
    private string? wanAccessType;

    public WanCommonInterfaceConfigSetWanAccessTypeViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger)
        : base(deviceLoginInfo, logger)
    {
    }

    public string? WanAccessType
    {
        get => wanAccessType;
        set
        {
            if (SetProperty(ref wanAccessType, value))
                DefaultCommand.NotifyCanExecuteChanged();
        }
    }

    protected override async Task DoExecuteDefaultCommandAsync(CancellationToken cancellationToken)
    {
        _ = await ExecuteApiAsync(q => q.WanCommonInterfaceConfigSetWanAccessTypeAsync(WanAccessType!));
    }

    protected override void FritzServiceViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        base.FritzServiceViewModelPropertyChanged(sender, e);

        switch (e.PropertyName)
        {
            case nameof(WanAccessType):
                {
                    UpdateCanExecuteDefaultCommand();
                    break;
                }
        }
    }

    protected override bool GetCanExecuteDefaultCommand()
    {
        return base.GetCanExecuteDefaultCommand() && !string.IsNullOrWhiteSpace(WanAccessType);
    }
}