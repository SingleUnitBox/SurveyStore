﻿using System.Threading.Tasks;
using SurveyStore.Shared.Abstractions.Messaging;

namespace SurveyStore.Shared.Infrastructure.Messaging.Dispatchers
{
    internal sealed class AsyncMessageDispatcher : IAsyncMessageDispatcher
    {
        private readonly IMessageChannel _messageChannel;

        public AsyncMessageDispatcher(IMessageChannel messageChannel)
        {
            _messageChannel = messageChannel;
        }

        public async Task PublishAsync<TMessage>(TMessage message) where TMessage : class, IMessage
            => await _messageChannel.Writer.WriteAsync(message);
    }
}
