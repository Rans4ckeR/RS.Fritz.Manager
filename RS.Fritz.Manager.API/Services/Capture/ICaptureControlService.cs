namespace RS.Fritz.Manager.API;

public interface ICaptureControlService
{
    ValueTask<IEnumerable<CaptureInterfaceGroup>> GetInterfacesAsync(InternetGatewayDevice internetGatewayDevice, CancellationToken cancellationToken = default);

    ValueTask StartCaptureAsync(InternetGatewayDevice internetGatewayDevice, FileInfo fileInfo, CaptureInterface captureInterface, int packetCaptureSizeLimit = 1600, CancellationToken cancellationToken = default);

    ValueTask StopCaptureAsync(InternetGatewayDevice internetGatewayDevice, CaptureInterface captureInterface, CancellationToken cancellationToken = default);
}