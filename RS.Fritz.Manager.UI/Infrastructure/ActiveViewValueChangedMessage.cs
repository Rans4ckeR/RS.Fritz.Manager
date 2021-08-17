namespace RS.Fritz.Manager.UI
{
    using CommunityToolkit.Mvvm.ComponentModel;
    using CommunityToolkit.Mvvm.Messaging.Messages;

    internal sealed class ActiveViewValueChangedMessage : ValueChangedMessage<ObservableObject>
    {
        public ActiveViewValueChangedMessage(ObservableObject activeView)
            : base(activeView)
        {
        }
    }
}