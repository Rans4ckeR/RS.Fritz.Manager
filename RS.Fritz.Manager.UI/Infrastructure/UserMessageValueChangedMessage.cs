namespace RS.Fritz.Manager.UI
{
    using CommunityToolkit.Mvvm.Messaging.Messages;

    public sealed class UserMessageValueChangedMessage : ValueChangedMessage<UserMessage>
    {
        public UserMessageValueChangedMessage(UserMessage userMessage)
            : base(userMessage)
        {
        }
    }
}