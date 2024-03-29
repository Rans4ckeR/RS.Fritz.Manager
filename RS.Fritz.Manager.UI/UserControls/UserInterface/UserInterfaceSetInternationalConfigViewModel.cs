﻿namespace RS.Fritz.Manager.UI;

using System.ComponentModel;

internal sealed class UserInterfaceSetInternationalConfigViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger)
    : ManualOperationViewModel<UserInterfaceSetInternationalConfigRequest, UserInterfaceSetInternationalConfigResponse>(deviceLoginInfo, logger, "SetInternationalConfig", "Set InternationalConfig", (d, r) => d.UserInterfaceSetInternationalConfigAsync(r))
{
    private string? language;
    private string? country;
    private string? annex;

    public string? Language
    {
        get => language;
        set
        {
            if (SetProperty(ref language, value))
                DefaultCommand.NotifyCanExecuteChanged();
        }
    }

    public string? Country
    {
        get => country;
        set
        {
            if (SetProperty(ref country, value))
                DefaultCommand.NotifyCanExecuteChanged();
        }
    }

    public string? Annex
    {
        get => annex;
        set
        {
            if (SetProperty(ref annex, value))
                DefaultCommand.NotifyCanExecuteChanged();
        }
    }

    protected override UserInterfaceSetInternationalConfigRequest BuildRequest()
        => new(Language!, Country!, Annex!);

    protected override void FritzServiceViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        base.FritzServiceViewModelPropertyChanged(sender, e);

        switch (e.PropertyName)
        {
            case nameof(Language):
            case nameof(Country):
            case nameof(Annex):
                {
                    UpdateCanExecuteDefaultCommand();
                    break;
                }
        }
    }
}