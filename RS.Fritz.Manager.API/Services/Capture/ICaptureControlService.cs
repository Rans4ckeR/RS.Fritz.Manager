namespace RS.Fritz.Manager.API;

public interface ICaptureControlService
{
    Task<IEnumerable<CaptureInterfaceGroup>> GetInterfacesAsync(InternetGatewayDevice internetGatewayDevice, CancellationToken cancellationToken = default);

    Task StartCaptureAsync(InternetGatewayDevice internetGatewayDevice, FileInfo fileInfo, CaptureInterface captureInterface, int packetCaptureSizeLimit = 1600, CancellationToken cancellationToken = default);

    Task StopCaptureAsync(InternetGatewayDevice internetGatewayDevice, CaptureInterface captureInterface, CancellationToken cancellationToken = default);
}