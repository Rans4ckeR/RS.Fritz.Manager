namespace RS.Fritz.Manager.UI;

using System.ComponentModel;

internal sealed class ManagementServerSetTr069FirmwareDownloadEnabledViewModel : ManualOperationViewModel<ManagementServerSetTr069FirmwareDownloadEnabledRequest, ManagementServerSetTr069FirmwareDownloadEnabledResponse>
{
    private bool? tr069FirmwareDownloadEnabled;

    public ManagementServerSetTr069FirmwareDownloadEnabledViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger)
        : base(deviceLoginInfo, logger, "SetTr069FirmwareDownloadEnabled", "Update Tr069FirmwareDownloadEnabled", (d, r) => d.ManagementServerSetTr069FirmwareDownloadEnabledAsync(r))
    {
    }

    public bool? Tr069FirmwareDownloadEnabled
    {
        get => tr069FirmwareDownloadEnabled;
        set
        {
            if (SetProperty(ref tr069FirmwareDownloadEnabled, value))
                DefaultCommand.NotifyCanExecuteChanged();
        }
    }

    protected override ManagementServerSetTr069FirmwareDownloadEnabledRequest BuildRequest()
        => new(Tr069FirmwareDownloadEnabled!.Value);

    protected override void FritzServiceViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        base.FritzServiceViewModelPropertyChanged(sender, e);

        switch (e.PropertyName)
        {
            case nameof(Tr069FirmwareDownloadEnabled):
                {
                    UpdateCanExecuteDefaultCommand();
                    break;
                }
        }
    }

    protected override bool GetCanExecuteDefaultCommand()
        => base.GetCanExecuteDefaultCommand() && Tr069FirmwareDownloadEnabled.HasValue;
}