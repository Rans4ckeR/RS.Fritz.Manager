﻿namespace RS.Fritz.Manager.UI
{
    using System;
    using CommunityToolkit.Mvvm.Messaging;
    using Microsoft.Extensions.Logging;
    using RS.Fritz.Manager.API;

    public sealed class UserInterfaceLogService : ILogger
    {
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            if (!IsEnabled(logLevel))
                return;

            string message = formatter(state, exception);

            WeakReferenceMessenger.Default.Send(new UserMessageValueChangedMessage(new UserMessage(message)));
        }

        public bool IsEnabled(LogLevel logLevel) => logLevel >= LogLevel.Error;

        public IDisposable BeginScope<TState>(TState state) => throw new NotSupportedException();
    }
}