namespace RS.Fritz.Manager.UI;

using System.ComponentModel;

internal sealed class LanConfigSecuritySetConfigPasswordViewModel : ManualOperationViewModel<LanConfigSecuritySetConfigPasswordRequest, LanConfigSecuritySetConfigPasswordResponse>
{
    private string? password;

    public LanConfigSecuritySetConfigPasswordViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger)
        : base(deviceLoginInfo, logger, "SetConfigPassword", "Update Password", (d, r) => d.LanConfigSecuritySetConfigPasswordAsync(r))
    {
    }

    public string? Password
    {
        get => password;
        set
        {
            if (SetProperty(ref password, value))
                DefaultCommand.NotifyCanExecuteChanged();
        }
    }

    protected override LanConfigSecuritySetConfigPasswordRequest BuildRequest()
        => new(Password!);

    protected override void FritzServiceViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        base.FritzServiceViewModelPropertyChanged(sender, e);

        switch (e.PropertyName)
        {
            case nameof(Password):
                {
                    UpdateCanExecuteDefaultCommand();
                    break;
                }
        }
    }
}