namespace RS.Fritz.Manager.UI
{
    using CommunityToolkit.Mvvm.Messaging.Messages;
    using RS.Fritz.Manager.API;

    public sealed class UserMessageValueChangedMessage : ValueChangedMessage<UserMessage>
    {
        public UserMessageValueChangedMessage(UserMessage userMessage)
            : base(userMessage)
        {
        }
    }
}