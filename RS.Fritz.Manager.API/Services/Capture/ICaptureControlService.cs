namespace RS.Fritz.Manager.API;

public interface ICaptureControlService
{
    Task<FileInfo> GetStartCaptureResponseAsync(InternetGatewayDevice internetGateway, string folderPath, string filePrefix, CancellationToken cancellationToken = default);

    Task GetStopCaptureResponseAsync(InternetGatewayDevice internetGateway, CancellationToken cancellationToken = default);
}