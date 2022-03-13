namespace RS.Fritz.Manager.UI;

using CommunityToolkit.Mvvm.Messaging.Messages;

internal sealed class UserMessageValueChangedMessage : ValueChangedMessage<UserMessage>
{
    public UserMessageValueChangedMessage(UserMessage userMessage)
        : base(userMessage)
    {
    }
}