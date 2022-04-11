namespace RS.Fritz.Manager.UI;

using CommunityToolkit.Mvvm.Input;

internal sealed class UserInterfaceCaptureInterface
{
    public CaptureInterface CaptureInterface { get; set; }

    public RelayCommand<CaptureInterface> StartCommand { get; set; }

    public AsyncRelayCommand<CaptureInterface> StopCommand { get; set; }

    public bool Active { get; set; }
}