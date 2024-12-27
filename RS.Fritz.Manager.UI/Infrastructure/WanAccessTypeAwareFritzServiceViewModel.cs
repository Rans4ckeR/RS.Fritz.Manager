using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;

namespace RS.Fritz.Manager.UI;

internal abstract class WanAccessTypeAwareFritzServiceViewModel : FritzServiceViewModel
{
    private readonly WanAccessType wanAccessType;

    protected WanAccessTypeAwareFritzServiceViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger, WanAccessType wanAccessType, string requiredServiceType)
        : base(deviceLoginInfo, logger, requiredServiceType)
    {
        this.wanAccessType = wanAccessType;
        StrongReferenceMessenger.Default.Register<PropertyChangedMessage<WanAccessType?>>(this, static (r, m) => ((WanAccessTypeAwareFritzServiceViewModel)r).Receive(m));
    }

    protected override bool GetCanExecuteDefaultCommand()
        => base.GetCanExecuteDefaultCommand() && DeviceLoginInfo.WanAccessType == wanAccessType;

    private void Receive(PropertyChangedMessage<WanAccessType?> message)
    {
        if (message.Sender != DeviceLoginInfo)
            return;

        switch (message.PropertyName)
        {
            case nameof(DeviceLoginInfo.WanAccessType):
                {
                    UpdateCanExecuteDefaultCommand();
                    break;
                }
        }
    }
}