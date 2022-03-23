﻿namespace RS.Fritz.Manager.UI;

using System.ComponentModel;

internal sealed class Layer3ForwardingGetGenericForwardingEntryViewModel : FritzServiceViewModel
{
    private ushort? index;
    private ushort? forwardNumberOfEntries;
    private Layer3ForwardingGetGenericForwardingEntryResponse? layer3ForwardingGetGenericForwardingEntryResponse;

    public Layer3ForwardingGetGenericForwardingEntryViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger)
        : base(deviceLoginInfo, logger)
    {
    }

    public ushort? Index
    {
        get => index;
        set
        {
            if (SetProperty(ref index, value))
                DefaultCommand.NotifyCanExecuteChanged();
        }
    }

    public ushort? ForwardNumberOfEntries
    {
        get => forwardNumberOfEntries;
        set
        {
            if (SetProperty(ref forwardNumberOfEntries, value))
                DefaultCommand.NotifyCanExecuteChanged();
        }
    }

    public Layer3ForwardingGetGenericForwardingEntryResponse? Layer3ForwardingGetGenericForwardingEntryResponse
    {
        get => layer3ForwardingGetGenericForwardingEntryResponse;
        private set { _ = SetProperty(ref layer3ForwardingGetGenericForwardingEntryResponse, value); }
    }

    protected override async Task DoExecuteDefaultCommandAsync(CancellationToken cancellationToken = default)
    {
        Layer3ForwardingGetGenericForwardingEntryResponse = await DeviceLoginInfo.InternetGatewayDevice!.ApiDevice.Layer3ForwardingGetGenericForwardingEntryAsync(Index!.Value);
    }

    protected override void FritzServiceViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        base.FritzServiceViewModelPropertyChanged(sender, e);

        switch (e.PropertyName)
        {
            case nameof(Index):
                {
                    UpdateCanExecuteDefaultCommand();
                    break;
                }
        }
    }

    protected override bool GetCanExecuteDefaultCommand()
    {
        return base.GetCanExecuteDefaultCommand() && Index >= 0 && Index < ForwardNumberOfEntries;
    }
}