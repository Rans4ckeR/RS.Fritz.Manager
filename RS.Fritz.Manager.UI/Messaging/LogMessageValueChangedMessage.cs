using CommunityToolkit.Mvvm.Messaging.Messages;

namespace RS.Fritz.Manager.UI;

internal sealed class LogMessageValueChangedMessage(UserMessage userMessage) : ValueChangedMessage<UserMessage>(userMessage);