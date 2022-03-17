namespace RS.Fritz.Manager.UI;

using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.Logging;
using RS.Fritz.Manager.API;

internal sealed class CaptureControlCaptureViewModel : FritzServiceViewModel
{
    private const int TimerTickIntervalMs = 200;
    private const string CapturePath = $"/cgi-bin/capture_notimeout";
    private const string Scheme = "http";
    private const string Host = "fritz.box";

    private readonly ICaptureControlService captureControlService;
    private readonly DispatcherTimer animationTimer;

    private int progBarPercent01;
    private Visibility progBarVisibility01 = Visibility.Hidden;
    private bool startButtonIsEnabled01;
    private int captureTimeLimitMinutes;
    private string filenamePrefix = "FritzboxCapture";
    private string selectedTargetFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
    private string targetFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
    private int milliSecondsCaptured;
    private ObservableCollection<string> targetFolders = new() { string.Empty };

    public CaptureControlCaptureViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger, ICaptureControlService captureControlService)
           : base(deviceLoginInfo, logger)
    {
        this.captureControlService = captureControlService;
        Start_1_Command = new AsyncRelayCommand(DoExecute_Start_1_Command_Async);
        Stop_1_Command = new AsyncRelayCommand(DoExecute_Stop_1_Command_Async);
        animationTimer = new DispatcherTimer()
        {
            Interval = TimeSpan.FromMilliseconds(TimerTickIntervalMs)
        };
        animationTimer.Tick += AnimationTimer_Tick;
        CaptureTimeLimitMinutes = 5;
        TargetFolders = new ObservableCollection<string>()
            {
                "Downloads",
                "Documents",
                "Desktop"
            };
        SelectedTargetFolder = TargetFolders[0];
        StartButtonIsEnabled01 = true;
    }

    public int ProgBarPercent01 { get => progBarPercent01; set => _ = SetProperty(ref progBarPercent01, value); }

    public Visibility ProgBarVisibility01 { get => progBarVisibility01; set => _ = SetProperty(ref progBarVisibility01, value); }

    public bool StartButtonIsEnabled01 { get => startButtonIsEnabled01; set => _ = SetProperty(ref startButtonIsEnabled01, value); }

    public string FilenamePrefix { get => filenamePrefix; set => _ = SetProperty(ref filenamePrefix, value); }

    public ObservableCollection<string> TargetFolders { get => targetFolders; set => _ = SetProperty(ref targetFolders, value); }

    public IAsyncRelayCommand? Start_1_Command { get; }

    public IAsyncRelayCommand? Stop_1_Command { get; }

    public int CaptureTimeLimitMinutes
    {
        get => captureTimeLimitMinutes;
        set
        {
            value = value == 100 ? 9999 : value;
            _ = SetProperty(ref captureTimeLimitMinutes, value);
        }
    }

    public string SelectedTargetFolder
    {
        get => selectedTargetFolder;
        set
        {
            _ = SetProperty(ref selectedTargetFolder, value);
            targetFolder = UpdateFolderPath(value);
        }
    }

    protected override async Task DoExecuteDefaultCommandAsync(CancellationToken cancellationToken = default)
    {
        // do nothing
        await Task.Delay(1, CancellationToken.None);
    }

    private static string UpdateFolderPath(string folderPath)
    {
        string returnPath;
        switch (folderPath)
        {
            case "Documents":
                {
                    returnPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    break;
                }

            case "Downloads":
                {
                    returnPath = SpecialFolder.Downloads;
                    break;
                }

            case "Desktop":
                {
                    returnPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    break;
                }

            default:
                {
                    returnPath = FormattableString.Invariant($"{Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)}\\{folderPath}");
                    break;
                }
        }

        return returnPath;
    }

    private static async Task<bool> InvalidTargetPath(string targetFolder, string filenamePrefix)
    {
        char[] invalidFileNameChars = Path.GetInvalidFileNameChars();

        bool invalidFilename = false;

        if (filenamePrefix.IndexOfAny(invalidFileNameChars) != -1)
        {
            invalidFilename = true;
        }

        targetFolder = invalidFilename ? "ThisIsAnInvalidPath::::" : targetFolder;

        try
        {
            if (!Directory.Exists(targetFolder))
            {
#pragma warning disable IDE0058 // Der Ausdruckswert wird niemals verwendet.

                Directory.CreateDirectory(targetFolder);

#pragma warning restore IDE0058 // Der Ausdruckswert wird niemals verwendet.
            }

            return false;
        }
        catch
        {
#pragma warning disable IDE0058 // Der Ausdruckswert wird niemals verwendet.
            _ = WeakReferenceMessenger.Default.Send(new UserMessageValueChangedMessage(new UserMessage("Invalid character in TargetFolder or FilenamePrefix")));
            await Task.Delay(3000);
            _ = WeakReferenceMessenger.Default.Send(new UserMessageValueChangedMessage(new UserMessage(string.Empty)));
#pragma warning restore IDE0058 // Der Ausdruckswert wird niemals verwendet.
            return true;
        }
    }

    private async Task DoExecute_Start_1_Command_Async()
    {
        string sid = await GetSidAsync();
        const string iface = "2-1";
        string query = FormattableString.Invariant($"sid={sid}&capture=Start&snaplen=1600&ifaceorminor={iface}");
        var captureUri = new Uri(FormattableString.Invariant($"{Scheme}://{Host}{CapturePath}?{query}"));

        if (await InvalidTargetPath(targetFolder, FilenamePrefix))
        {
            return;
        }

        ProgBarVisibility01 = Visibility.Visible;
        animationTimer.Start();
        milliSecondsCaptured = 0;
        StartButtonIsEnabled01 = false;
        await captureControlService.GetStartCaptureResponseAsync(captureUri, targetFolder, filenamePrefix);

        progBarPercent01 = 0;
        animationTimer.Stop();
        ProgBarVisibility01 = Visibility.Hidden;
        StartButtonIsEnabled01 = true;
    }

    private async Task DoExecute_Stop_1_Command_Async()
    {
        string sid = await GetSidAsync();
        string iface = "eth_udma0";
        string timeString20 = DateTime.UtcNow.Ticks.ToString("D20", CultureInfo.InvariantCulture);
        string timeId = FormattableString.Invariant($"t{timeString20[^13..]}");
        var captureUri = new Uri(FormattableString.Invariant($"{Scheme}://{Host}{CapturePath}?iface={iface}&minor=1&type=2&capture=Stop&sid={sid}&useajax=1&xhr=1&{timeId}=nocache"));
        await captureControlService.GetStopCaptureResponseAsync(captureUri);
        StartButtonIsEnabled01 = true;
    }

    private async void AnimationTimer_Tick(object? sender, EventArgs e)
    {
        ProgBarPercent01 = (progBarPercent01 + 1) % 10;
        milliSecondsCaptured += TimerTickIntervalMs;
        if (milliSecondsCaptured > CaptureTimeLimitMinutes * 60 * 1000)
        {
            animationTimer.Stop();

            await DoExecute_Stop_1_Command_Async();
        }
    }

    private async Task<string> GetSidAsync()
    {
        HostsGetHostListPathResponse newHostsGetHostListPathResponse = await DeviceLoginInfo.InternetGatewayDevice!.ApiDevice.HostsGetHostListPathAsync();
        string hostListPath = newHostsGetHostListPathResponse.HostListPath;

        //string returnString = hostListPath.Substring((hostListPath.LastIndexOf("sid=") != -1) ? hostListPath.LastIndexOf("sid=") : hostListPath.Length - 1);
        string returnString = hostListPath[((hostListPath.LastIndexOf("sid=", StringComparison.InvariantCulture) != -1) ? hostListPath.LastIndexOf("sid=", StringComparison.InvariantCulture) : hostListPath.Length - 1)..];

        returnString = returnString.Length >= 4 ? returnString.Remove(0, 4) : string.Empty;
        return returnString;
    }
}