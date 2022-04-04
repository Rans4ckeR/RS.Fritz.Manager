namespace RS.Fritz.Manager.UI;

using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Threading;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

internal sealed class CaptureControlCaptureViewModel : FritzServiceViewModel
{
    private const int TimerTickIntervalMs = 200;

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

    protected override Task DoExecuteDefaultCommandAsync(CancellationToken cancellationToken)
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

    private static bool InvalidTargetPath(string targetFolder, string filenamePrefix)
    {
        char[] invalidFileNameChars = Path.GetInvalidFileNameChars();
        bool invalidFilename = filenamePrefix.IndexOfAny(invalidFileNameChars) != -1;

        targetFolder = invalidFilename ? "ThisIsAnInvalidPath::::" : targetFolder;

        try
        {
            var directoryInfo = new DirectoryInfo(targetFolder);

            if (!directoryInfo.Exists)
                directoryInfo.Create();

            return false;
        }
        catch (IOException)
        {
            _ = WeakReferenceMessenger.Default.Send(new UserMessageValueChangedMessage(new UserMessage("Invalid character in TargetFolder or FilenamePrefix")));

            return true;
        }
    }

    private async Task DoExecuteStart1CommandAsync(CancellationToken cancellationToken)
    {
        if (InvalidTargetPath(targetFolder, FilenamePrefix))
            return;

        ProgBarVisibility01 = Visibility.Visible;
        animationTimer.Start();
        miliSecondsCaptured = 0;
        StartButtonIsEnabled01 = false;

        _ = await captureControlService.GetStartCaptureResponseAsync(ApiDevice, targetFolder, filenamePrefix, cancellationToken);

        progBarPercent01 = 0;
        animationTimer.Stop();
        ProgBarVisibility01 = Visibility.Hidden;
        StartButtonIsEnabled01 = true;
    }

    private async Task DoExecuteStop1CommandAsync(CancellationToken cancellationToken)
    {
        await captureControlService.GetStopCaptureResponseAsync(ApiDevice, cancellationToken);

        StartButtonIsEnabled01 = true;
    }

    private async void AnimationTimer_Tick(object? sender, EventArgs e)
    {
        ProgBarPercent01 = (progBarPercent01 + 1) % 10;
        miliSecondsCaptured += TimerTickIntervalMs;

        if (miliSecondsCaptured > CaptureTimeLimitMinutes * 60 * 1000)
        {
            animationTimer.Stop();
            await DoExecuteStop1CommandAsync(CancellationToken.None);
        }
    }
}