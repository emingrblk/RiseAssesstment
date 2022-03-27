

 
using Core.Utilities.ViewModels;

namespace Business.MessageBrokers.RabbitMq
{
    public interface IMessageBrokerHelper
    {
        void QueueMessage(IRequestModel model);
    }
}
