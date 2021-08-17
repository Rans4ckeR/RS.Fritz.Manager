namespace RS.Fritz.Manager.UI
{
    using CommunityToolkit.Mvvm.Messaging.Messages;
    using RS.Fritz.Manager.Domain;

    public sealed class UserMessageValueChangedMessage : ValueChangedMessage<UserMessage>
    {
        public UserMessageValueChangedMessage(UserMessage userMessage)
            : base(userMessage)
        {
        }
    }
}