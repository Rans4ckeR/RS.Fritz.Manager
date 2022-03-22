namespace RS.Fritz.Manager.UI;

using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Windows;
using System.Windows.Threading;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

internal sealed class CaptureControlCaptureViewModel : FritzServiceViewModel
{
    private const int TimerTickIntervalMs = 200;
    private const string CapturePath = "/cgi-bin/capture_notimeout";
    private const string Scheme = "http";

    private readonly ICaptureControlService captureControlService;
    private readonly DispatcherTimer animationTimer;

    private int progBarPercent01;
    private Visibility progBarVisibility01 = Visibility.Hidden;
    private bool startButtonIsEnabled01 = true;
    private int captureTimeLimitMinutes = 5;
    private string filenamePrefix = "FritzboxCapture";
    private string selectedTargetFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
    private string targetFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
    private int miliSecondsCaptured;

    public CaptureControlCaptureViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger, ICaptureControlService captureControlService)
           : base(deviceLoginInfo, logger)
    {
        this.captureControlService = captureControlService;
        Start1Command = new AsyncRelayCommand(DoExecuteStart1CommandAsync);
        Stop1Command = new AsyncRelayCommand(DoExecuteStop1CommandAsync);
        animationTimer = new DispatcherTimer()
        {
            Interval = TimeSpan.FromMilliseconds(TimerTickIntervalMs)
        };
        animationTimer.Tick += AnimationTimer_Tick;
        SelectedTargetFolder = TargetFolders[0];
    }

    public int ProgBarPercent01 { get => progBarPercent01; set => _ = SetProperty(ref progBarPercent01, value); }

    public Visibility ProgBarVisibility01 { get => progBarVisibility01; set => _ = SetProperty(ref progBarVisibility01, value); }

    public bool StartButtonIsEnabled01 { get => startButtonIsEnabled01; set => _ = SetProperty(ref startButtonIsEnabled01, value); }

    public string FilenamePrefix { get => filenamePrefix; set => _ = SetProperty(ref filenamePrefix, value); }

    public ObservableCollection<string> TargetFolders { get; } = new()
        {
            "Downloads",
            "Documents",
            "Desktop"
        };

    public IAsyncRelayCommand? Start1Command { get; }

    public IAsyncRelayCommand? Stop1Command { get; }

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
            if (SetProperty(ref selectedTargetFolder, value))
                targetFolder = UpdateFolderPath(value);
        }
    }

    protected override Task DoExecuteDefaultCommandAsync(CancellationToken cancellationToken = default)
    {
        return Task.CompletedTask;
    }

    private static string UpdateFolderPath(string folderPath) => folderPath switch
    {
        "Documents" => Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
        "Downloads" => SpecialFolder.Downloads,
        "Desktop" => Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
        _ => FormattableString.Invariant($"{Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)}\\{folderPath}")
    };

    private static async Task<bool> InvalidTargetPath(string targetFolder, string filenamePrefix)
    {
        char[] invalidFileNameChars = Path.GetInvalidFileNameChars();
        bool invalidFilename = filenamePrefix.IndexOfAny(invalidFileNameChars) != -1;

        targetFolder = invalidFilename ? "ThisIsAnInvalidPath::::" : targetFolder;

        try
        {
            if (!Directory.Exists(targetFolder))
                _ = Directory.CreateDirectory(targetFolder);

            return false;
        }
        catch
        {
            _ = WeakReferenceMessenger.Default.Send(new UserMessageValueChangedMessage(new UserMessage("Invalid character in TargetFolder or FilenamePrefix")));

            await Task.Delay(3000);

            _ = WeakReferenceMessenger.Default.Send(new UserMessageValueChangedMessage(new UserMessage(string.Empty)));

            return true;
        }
    }

    private async Task DoExecuteStart1CommandAsync()
    {
        string sid = await GetSidAsync();
        const string iface = "2-1";
        string query = FormattableString.Invariant($"sid={sid}&capture=Start&snaplen=1600&ifaceorminor={iface}");
        var captureUri = new Uri(FormattableString.Invariant($"{Scheme}://{DeviceLoginInfo.InternetGatewayDevice!.ApiDevice.PreferredLocation.Host}{CapturePath}?{query}"));

        if (await InvalidTargetPath(targetFolder, FilenamePrefix))
            return;

        ProgBarVisibility01 = Visibility.Visible;
        animationTimer.Start();
        miliSecondsCaptured = 0;
        StartButtonIsEnabled01 = false;
        await captureControlService.GetStartCaptureResponseAsync(captureUri, targetFolder, filenamePrefix);

        progBarPercent01 = 0;
        animationTimer.Stop();
        ProgBarVisibility01 = Visibility.Hidden;
        StartButtonIsEnabled01 = true;
    }

    private async Task DoExecuteStop1CommandAsync()
    {
        string sid = await GetSidAsync();
        const string iface = "eth_udma0";
        string timeString20 = DateTime.UtcNow.Ticks.ToString("D20", CultureInfo.InvariantCulture);
        string timeId = FormattableString.Invariant($"t{timeString20[^13..]}");
        var captureUri = new Uri(FormattableString.Invariant($"{Scheme}://{DeviceLoginInfo.InternetGatewayDevice!.ApiDevice.PreferredLocation.Host}{CapturePath}?iface={iface}&minor=1&type=2&capture=Stop&sid={sid}&useajax=1&xhr=1&{timeId}=nocache"));

        await captureControlService.GetStopCaptureResponseAsync(captureUri);

        StartButtonIsEnabled01 = true;
    }

    private async void AnimationTimer_Tick(object? sender, EventArgs e)
    {
        ProgBarPercent01 = (progBarPercent01 + 1) % 10;
        miliSecondsCaptured += TimerTickIntervalMs;

        if (miliSecondsCaptured > CaptureTimeLimitMinutes * 60 * 1000)
        {
            animationTimer.Stop();
            await DoExecuteStop1CommandAsync();
        }
    }

    private async Task<string> GetSidAsync()
    {
        HostsGetHostListPathResponse newHostsGetHostListPathResponse = await DeviceLoginInfo.InternetGatewayDevice!.ApiDevice.HostsGetHostListPathAsync();
        string hostListPath = newHostsGetHostListPathResponse.HostListPath;
        string returnString = hostListPath[(hostListPath.LastIndexOf("sid=", StringComparison.InvariantCulture) != -1 ? hostListPath.LastIndexOf("sid=", StringComparison.InvariantCulture) : hostListPath.Length - 1)..];

        returnString = returnString.Length >= 4 ? returnString.Remove(0, 4) : string.Empty;

        return returnString;
    }
}