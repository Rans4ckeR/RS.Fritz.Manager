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
    private Dictionary<CaptureInterface, UserInterfaceCaptureInterface>? captureInterfaceDictionary;

    public CaptureControlCaptureViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger, ICaptureControlService captureControlService)
           : base(deviceLoginInfo, logger)
    {
        this.captureControlService = captureControlService;
        SelectTargetFolderCommand = new AsyncRelayCommand(DoExecuteSelectTargetFolderCommandAsync);
    }

    public IAsyncRelayCommand SelectTargetFolderCommand { get; }

    public string FolderName
    {
        get => folderName;
        set
        {
            if (SetProperty(ref folderName, value))
                CaptureInterfaceDictionary?.Values.ToList().ForEach(q => q.StartCommand.NotifyCanExecuteChanged());
        }
    }

    public int PacketCaptureSizeLimit
    {
        get => packetCaptureSizeLimit;
        set
        {
            if (SetProperty(ref packetCaptureSizeLimit, value))
                CaptureInterfaceDictionary?.Values.ToList().ForEach(q => q.StartCommand.NotifyCanExecuteChanged());
        }
    }

    public ObservableCollection<CaptureInterfaceGroup>? CaptureInterfaceGroups
    {
        get => captureInterfaceGroups;
        private set
        {
            if (SetProperty(ref captureInterfaceGroups, value))
                CaptureInterfaceDictionary = value!.SelectMany(q => q.CaptureInterfaces).ToDictionary(q => q, q => new UserInterfaceCaptureInterface { CaptureInterface = q, StartCommand = new RelayCommand<CaptureInterface>(DoExecuteCaptureInterfaceStartCommand, CanExecuteCaptureInterfaceStartCommand), StopCommand = new AsyncRelayCommand<CaptureInterface>(DoExecuteCaptureInterfaceStopCommandAsync, CanExecuteCaptureInterfaceStopCommand) });
        }
    }

    public Dictionary<CaptureInterface, UserInterfaceCaptureInterface>? CaptureInterfaceDictionary
    {
        get => captureInterfaceDictionary;
        private set
        {
            if (SetProperty(ref captureInterfaceDictionary, value))
            {
                CaptureInterfaceDictionary?.Values.ToList().ForEach(q => q.StartCommand.NotifyCanExecuteChanged());
                CaptureInterfaceDictionary?.Values.ToList().ForEach(q => q.StopCommand.NotifyCanExecuteChanged());
            }
        }
    }

    protected override async Task DoExecuteDefaultCommandAsync(CancellationToken cancellationToken)
    {
        CaptureInterfaceGroups = new ObservableCollection<CaptureInterfaceGroup>(await captureControlService.GetInterfacesAsync(ApiDevice, cancellationToken));
    }

    private bool CanExecuteCaptureInterfaceStartCommand(CaptureInterface captureInterface)
    {
        return PacketCaptureSizeLimit > 0 && !string.IsNullOrWhiteSpace(FolderName) && !CaptureInterfaceDictionary![captureInterface].Active;
    }

    private bool CanExecuteCaptureInterfaceStopCommand(CaptureInterface captureInterface)
    {
        return CaptureInterfaceDictionary![captureInterface].Active;
    }

    private async Task DoExecuteSelectTargetFolderCommandAsync(CancellationToken cancellationToken)
    {
        IntPtr mainWindowHandle = new WindowInteropHelper(Application.Current.MainWindow).Handle;
        var folderPicker = new FolderPicker
        {
            SuggestedStartLocation = PickerLocationId.Downloads
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
        UserInterfaceCaptureInterface userInterfaceCaptureInterface = CaptureInterfaceDictionary![captureInterface];

        userInterfaceCaptureInterface.Active = commandActive;

        userInterfaceCaptureInterface.StartCommand.NotifyCanExecuteChanged();
        userInterfaceCaptureInterface.StopCommand.NotifyCanExecuteChanged();
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