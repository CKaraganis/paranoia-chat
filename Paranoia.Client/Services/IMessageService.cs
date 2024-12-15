using static uPLibrary.Networking.M2Mqtt.MqttClient;

namespace Paranoia.Client.Services
{
    public interface IMessageService
    {
        void SendMessage(string topicName, string message);

        void Subscribe(string topicName, MqttMsgPublishEventHandler HandleMessageReceived);

        void Unsubscribe(string topicName);
    }
}
