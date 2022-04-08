namespace RS.Fritz.Manager.API;

public interface ICaptureControlService
{
    Task<FileInfo> GetStartCaptureResponseAsync(InternetGatewayDevice internetGatewayDevice, string folderPath, string filePrefix, CancellationToken cancellationToken = default);

    Task GetStopCaptureResponseAsync(InternetGatewayDevice internetGatewayDevice, CancellationToken cancellationToken = default);
}