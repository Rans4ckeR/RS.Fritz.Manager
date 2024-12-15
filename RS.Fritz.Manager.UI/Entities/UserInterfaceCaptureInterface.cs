using CommunityToolkit.Mvvm.Input;

namespace RS.Fritz.Manager.UI;

internal sealed record UserInterfaceCaptureInterface(CaptureInterface CaptureInterface, AsyncRelayCommand<UserInterfaceCaptureInterface> StartCommand, AsyncRelayCommand<UserInterfaceCaptureInterface> StopCommand)
{
    public bool Active { get; set; }
}