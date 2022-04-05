namespace RS.Fritz.Manager.UI;

using System.ComponentModel;

internal sealed class ManagementServerSetManagementServerUrlViewModel : ExecuteOperationViewModel<ManagementServerSetManagementServerUrlRequest, ManagementServerSetManagementServerUrlResponse>
{
    private string? url;

    public ManagementServerSetManagementServerUrlViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger)
        : base(deviceLoginInfo, logger, "SetManagementServerUrl", "Update ManagementServerUrl", (d, r) => d.ManagementServerSetManagementServerUrlAsync(r))
    {
    }

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
    {
        return new ManagementServerSetManagementServerUrlRequest(Url!);
    }

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