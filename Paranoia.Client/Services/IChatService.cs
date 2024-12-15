using Paranoia.Client.Enums;
using Paranoia.Client.Models;

namespace Paranoia.Client.Services
{
    public interface IChatService
    {
        List<string> GetChats();

        List<Message> GetChatHistory(string characterName);

        Dictionary<string, List<Message>> GetAllChatHistory();

        void RegisterChat(string characterName);

        void NukeChat(string characterName);

        void SendMessage(string characterName, string message, Sender sender);
    }
}
