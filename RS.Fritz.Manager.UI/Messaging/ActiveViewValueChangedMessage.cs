namespace RS.Fritz.Manager.UI;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging.Messages;

internal sealed class ActiveViewValueChangedMessage(ObservableObject activeView) : ValueChangedMessage<ObservableObject>(activeView)
{
}