using CommunityToolkit.Mvvm.Messaging.Messages;

namespace RS.Fritz.Manager.UI;

internal sealed class UserMessageValueChangedMessage(UserMessage userMessage) : ValueChangedMessage<UserMessage>(userMessage);