using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging.Messages;

namespace RS.Fritz.Manager.UI;

internal sealed class ActiveViewValueChangedMessage(ObservableObject activeView) : ValueChangedMessage<ObservableObject>(activeView);