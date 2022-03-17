namespace RS.Fritz.Manager.API;

using System;
using System.Threading.Tasks;

public interface ICaptureControlService
{
    Task GetStartCaptureResponseAsync(Uri uri, string folderPath, string filePrefix);

    Task GetStopCaptureResponseAsync(Uri uri);
}