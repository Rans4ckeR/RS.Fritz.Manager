namespace RS.Fritz.Manager.UI;

using CommunityToolkit.Mvvm.Messaging.Messages;

internal sealed class DeviceLoginInfoValueChangedMessage : ValueChangedMessage<DeviceLoginInfo>
{
    public DeviceLoginInfoValueChangedMessage(DeviceLoginInfo userMessage)
        : base(userMessage)
    {
    }
}