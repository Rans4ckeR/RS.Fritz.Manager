namespace RS.Fritz.Manager.UI;

using CommunityToolkit.Mvvm.Messaging.Messages;

internal sealed class UserMessageValueChangedMessage(UserMessage userMessage) : ValueChangedMessage<UserMessage>(userMessage)
{
}