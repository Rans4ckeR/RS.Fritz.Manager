namespace RS.Fritz.Manager.API;

public interface ICaptureControlService
{
    Task GetStartCaptureResponseAsync(Uri uri, string folderPath, string filePrefix);

    Task GetStopCaptureResponseAsync(Uri uri);
}