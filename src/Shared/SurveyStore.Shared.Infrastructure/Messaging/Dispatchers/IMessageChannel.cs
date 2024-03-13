using System.Threading.Channels;
using SurveyStore.Shared.Abstractions.Messaging;

namespace SurveyStore.Shared.Infrastructure.Messaging.Dispatchers
{
    public interface IMessageChannel
    {
        ChannelReader<IMessage> Reader { get; }
        ChannelWriter<IMessage> Writer { get; }
    }
}
