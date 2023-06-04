namespace RS.Fritz.Manager.UI;

using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Interop;
using CommunityToolkit.Mvvm.Input;
using Windows.Storage;
using Windows.Storage.Pickers;
using WinRT.Interop;

internal sealed class CaptureControlCaptureViewModel : FritzServiceViewModel
{
    private readonly ICaptureControlService captureControlService;

    private string folderName = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
    private int packetCaptureSizeLimit = 1600;
    private ObservableCollection<UserInterfaceCaptureInterfaceGroup>? captureInterfaceGroups;

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
                NotifyAllStartCommandsCanExecuteChanged();
        }
    }

    public int PacketCaptureSizeLimit
    {
        get => packetCaptureSizeLimit;
        set
        {
            if (SetProperty(ref packetCaptureSizeLimit, value))
                NotifyAllStartCommandsCanExecuteChanged();
        }
    }

    public ObservableCollection<UserInterfaceCaptureInterfaceGroup>? CaptureInterfaceGroups
    {
        get => captureInterfaceGroups;
        private set => _ = SetProperty(ref captureInterfaceGroups, value);
    }

    protected override async ValueTask DoExecuteDefaultCommandAsync(CancellationToken cancellationToken)
    {
        if (CaptureInterfaceGroups is not null)
            return;

        IEnumerable<UserInterfaceCaptureInterfaceGroup> newCaptureInterfaceGroups = (await captureControlService.GetInterfacesAsync(ApiDevice, cancellationToken)).Select(q => new UserInterfaceCaptureInterfaceGroup(q, q.CaptureInterfaces.Select(r => new UserInterfaceCaptureInterface(r, new(DoExecuteCaptureInterfaceStartCommand, _ => CanExecuteCaptureInterfaceStartCommand(r)), new(DoExecuteCaptureInterfaceStopCommandAsync, _ => CanExecuteCaptureInterfaceStopCommand(r)))).ToList()));

        CaptureInterfaceGroups = new(newCaptureInterfaceGroups);

        NotifyAllStartCommandsCanExecuteChanged();
    }

    private static void SetCaptureInterfaceStatus(UserInterfaceCaptureInterface userInterfaceCaptureInterface, bool commandActive)
    {
        userInterfaceCaptureInterface.Active = commandActive;

        userInterfaceCaptureInterface.StartCommand.NotifyCanExecuteChanged();
        userInterfaceCaptureInterface.StopCommand.NotifyCanExecuteChanged();
    }

    private void NotifyAllStartCommandsCanExecuteChanged()
        => CaptureInterfaceGroups?.ToList().ForEach(q => q.CaptureInterfaces.ForEach(r => r.StartCommand.NotifyCanExecuteChanged()));

    private bool CanExecuteCaptureInterfaceStartCommand(CaptureInterface captureInterface)
        => PacketCaptureSizeLimit > 0 && !string.IsNullOrWhiteSpace(FolderName) && (!CaptureInterfaceGroups?.SelectMany(q => q.CaptureInterfaces).Single(q => q.CaptureInterface == captureInterface).Active ?? false);

    private bool CanExecuteCaptureInterfaceStopCommand(CaptureInterface captureInterface)
        => CaptureInterfaceGroups?.SelectMany(q => q.CaptureInterfaces).Single(q => q.CaptureInterface == captureInterface).Active ?? false;

    private async Task DoExecuteSelectTargetFolderCommandAsync()
    {
        nint mainWindowHandle = new WindowInteropHelper(Application.Current.MainWindow!).Handle;
        var folderPicker = new FolderPicker
        {
            SuggestedStartLocation = PickerLocationId.Downloads
        };

        InitializeWithWindow.Initialize(folderPicker, mainWindowHandle);

        StorageFolder storageFolder = await folderPicker.PickSingleFolderAsync();

        if (storageFolder is not null)
            FolderName = storageFolder.Path;
    }

    private async void DoExecuteCaptureInterfaceStartCommand(UserInterfaceCaptureInterface? userInterfaceCaptureInterface)
    {
        SetCaptureInterfaceStatus(userInterfaceCaptureInterface!, true);

        var fileInfo = new FileInfo(FormattableString.Invariant($"{FolderName}\\{userInterfaceCaptureInterface!.CaptureInterface.Name}_{DateTime.Now.ToString("s").Replace(":", string.Empty, StringComparison.OrdinalIgnoreCase)}.eth"));

        await StartBackgroundCaptureAsync(userInterfaceCaptureInterface, fileInfo);
    }

    private async ValueTask StartBackgroundCaptureAsync(UserInterfaceCaptureInterface userInterfaceCaptureInterface, FileInfo fileInfo)
    {
        try
        {
            await captureControlService.StartCaptureAsync(ApiDevice, fileInfo, userInterfaceCaptureInterface.CaptureInterface, PacketCaptureSizeLimit);
        }
        catch (Exception ex)
        {
            Logger.ExceptionThrown(ex);
            SetCaptureInterfaceStatus(userInterfaceCaptureInterface, false);
        }
    }

    private async Task DoExecuteCaptureInterfaceStopCommandAsync(UserInterfaceCaptureInterface? userInterfaceCaptureInterface, CancellationToken cancellationToken)
    {
        await captureControlService.StopCaptureAsync(ApiDevice, userInterfaceCaptureInterface!.CaptureInterface, cancellationToken);
        SetCaptureInterfaceStatus(userInterfaceCaptureInterface, false);
    }
}