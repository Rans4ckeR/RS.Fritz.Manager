namespace RS.Fritz.Manager.UI;

using CommunityToolkit.Mvvm.Input;

internal sealed record UserInterfaceCaptureInterface(CaptureInterface CaptureInterface, RelayCommand<UserInterfaceCaptureInterface> StartCommand, AsyncRelayCommand<UserInterfaceCaptureInterface> StopCommand)
{
    public bool Active { get; set; }
}