namespace RS.Fritz.Manager.UI;

using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Interop;
using Windows.Storage;
using Windows.Storage.Pickers;
using CommunityToolkit.Mvvm.Input;
using WinRT.Interop;

internal sealed class CaptureControlCaptureViewModel : FritzServiceViewModel
{
    private readonly ICaptureControlService captureControlService;

    private string folderName = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
    private int packetCaptureSizeLimit = 1600;
    private ObservableCollection<CaptureInterfaceGroup>? captureInterfaceGroups;
    private Dictionary<CaptureInterface, bool>? captureInterfaceActiveDictionary;

    public CaptureControlCaptureViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger, ICaptureControlService captureControlService)
           : base(deviceLoginInfo, logger)
    {
        this.captureControlService = captureControlService;
        SelectTargetFolderCommand = new AsyncRelayCommand(DoExecuteSelectTargetFolderCommandAsync);
        CaptureInterfaceStartCommand = new RelayCommand<CaptureInterface>(DoExecuteCaptureInterfaceStartCommand, CanExecuteCaptureInterfaceStartCommand);
        CaptureInterfaceStopCommand = new AsyncRelayCommand<CaptureInterface>(DoExecuteCaptureInterfaceStopCommandAsync, CanExecuteCaptureInterfaceStopCommand);
    }

    public IAsyncRelayCommand SelectTargetFolderCommand { get; }

    public IRelayCommand CaptureInterfaceStartCommand { get; }

    public IAsyncRelayCommand CaptureInterfaceStopCommand { get; }

    public string FolderName
    {
        get => folderName;
        set
        {
            if (SetProperty(ref folderName, value))
                CaptureInterfaceStartCommand.NotifyCanExecuteChanged();
        }
    }

    public int PacketCaptureSizeLimit
    {
        get => packetCaptureSizeLimit;
        set
        {
            if (SetProperty(ref packetCaptureSizeLimit, value))
                CaptureInterfaceStartCommand.NotifyCanExecuteChanged();
        }
    }

    public ObservableCollection<CaptureInterfaceGroup>? CaptureInterfaceGroups
    {
        get => captureInterfaceGroups;
        private set
        {
            if (SetProperty(ref captureInterfaceGroups, value))
                CaptureInterfaceActiveDictionary = value!.SelectMany(q => q.CaptureInterfaces).ToDictionary(q => q, _ => false);
        }
    }

    private Dictionary<CaptureInterface, bool>? CaptureInterfaceActiveDictionary
    {
        get => captureInterfaceActiveDictionary;
        set => _ = SetProperty(ref captureInterfaceActiveDictionary, value);
    }

    protected override async Task DoExecuteDefaultCommandAsync(CancellationToken cancellationToken)
    {
        CaptureInterfaceGroups = new ObservableCollection<CaptureInterfaceGroup>(await captureControlService.GetInterfacesAsync(ApiDevice, cancellationToken));
    }

    private bool CanExecuteCaptureInterfaceStartCommand(CaptureInterface captureInterface)
    {
        return PacketCaptureSizeLimit > 0 && !string.IsNullOrWhiteSpace(FolderName) && !CaptureInterfaceActiveDictionary![captureInterface];
    }

    private bool CanExecuteCaptureInterfaceStopCommand(CaptureInterface captureInterface)
    {
        return CaptureInterfaceActiveDictionary![captureInterface];
    }

    private async Task DoExecuteSelectTargetFolderCommandAsync(CancellationToken cancellationToken)
    {
        IntPtr mainWindowHandle = new WindowInteropHelper(Application.Current.MainWindow).Handle;
        var folderPicker = new FolderPicker
        {
            SuggestedStartLocation = PickerLocationId.Desktop
        };

        InitializeWithWindow.Initialize(folderPicker, mainWindowHandle);

        StorageFolder storageFolder = await folderPicker.PickSingleFolderAsync();

        if (storageFolder is not null)
            FolderName = storageFolder.Path;
    }

    private async void DoExecuteCaptureInterfaceStartCommand(CaptureInterface captureInterface)
    {
        SetCaptureInterfaceStatus(captureInterface, true);

        var fileInfo = new FileInfo(FormattableString.Invariant($"{FolderName}\\{captureInterface.Name}_{DateTime.Now.ToString("s").Replace(":", string.Empty)}.eth"));

        await StartBackgroundCaptureAsync(captureInterface, fileInfo);
    }

    private void SetCaptureInterfaceStatus(CaptureInterface captureInterface, bool commandActive)
    {
        CaptureInterfaceActiveDictionary![captureInterface] = commandActive;

        CaptureInterfaceStartCommand.NotifyCanExecuteChanged();
        CaptureInterfaceStopCommand.NotifyCanExecuteChanged();
    }

    private async Task StartBackgroundCaptureAsync(CaptureInterface captureInterface, FileInfo fileInfo)
    {
        try
        {
            await captureControlService.StartCaptureAsync(ApiDevice, fileInfo, captureInterface, PacketCaptureSizeLimit);
        }
        catch (Exception ex)
        {
            Logger.ExceptionThrown(ex);
            SetCaptureInterfaceStatus(captureInterface, false);
        }
    }

    private async Task DoExecuteCaptureInterfaceStopCommandAsync(CaptureInterface captureInterface, CancellationToken cancellationToken)
    {
        await captureControlService.StopCaptureAsync(ApiDevice, captureInterface, cancellationToken);
        SetCaptureInterfaceStatus(captureInterface, false);
    }
}