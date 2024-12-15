using Microsoft.Extensions.Options;
using Paranoia.Client.Configuration;
using System.Text;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using static uPLibrary.Networking.M2Mqtt.MqttClient;

namespace Paranoia.Client.Services
{
    public class MessageService : IMessageService
    {
        private static readonly string _mqttClientId = Guid.NewGuid().ToString();
        private readonly MqttClient _mqttClient;

        public MessageService(IOptions<MessageOptions> options)
        {
            _mqttClient = new MqttClient(options.Value.HostName);
            _mqttClient.Connect(_mqttClientId);
        }

        public void SendMessage(string topicName, string message)
        {
            if (!_mqttClient.IsConnected)
                throw new Exception("Mqtt Client is not connected. PANIC!!!!!!!");

            var byteArray = Encoding.ASCII.GetBytes(message);

            _mqttClient.Publish(topicName, byteArray);
        }

        public void Subscribe(string topicName, MqttMsgPublishEventHandler HandleMessageReceived)
        {
            _mqttClient.Subscribe([topicName], [MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE]);
            _mqttClient.MqttMsgPublishReceived += HandleMessageReceived;
        }

        public void Unsubscribe(string topicName)
        {
            _mqttClient?.Unsubscribe([topicName]);
        }
    }
}
