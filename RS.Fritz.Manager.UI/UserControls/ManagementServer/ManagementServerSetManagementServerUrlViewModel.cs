namespace RS.Fritz.Manager.UI;

using System.ComponentModel;

internal sealed class ManagementServerSetManagementServerUrlViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger)
    : ManualOperationViewModel<ManagementServerSetManagementServerUrlRequest, ManagementServerSetManagementServerUrlResponse>(deviceLoginInfo, logger, "SetManagementServerUrl", "Update ManagementServerUrl", (d, r) => d.ManagementServerSetManagementServerUrlAsync(r))
{
    private string? url;

    public string? Url
    {
        get => url;
        set
        {
            if (SetProperty(ref url, value))
                DefaultCommand.NotifyCanExecuteChanged();
        }
    }

    protected override ManagementServerSetManagementServerUrlRequest BuildRequest()
        => new(Url!);

    protected override void FritzServiceViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        base.FritzServiceViewModelPropertyChanged(sender, e);

        switch (e.PropertyName)
        {
            case nameof(Url):
                {
                    UpdateCanExecuteDefaultCommand();
                    break;
                }
        }
    }
}