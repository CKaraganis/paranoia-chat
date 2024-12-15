﻿using Paranoia.Client.Enums;
using Paranoia.Client.Models;

namespace Paranoia.Client.Services
{
    public class ChatService : IChatService
    {
        private static Dictionary<string, List<Message>> Chats = [];

        private readonly IMessageService _messageService;

        public ChatService(IMessageService messageService) 
        {
            _messageService = messageService;

#if DEBUG
            if (!Chats.ContainsKey("Roy-G-BIV"))
                Chats.Add("Roy-G-BIV", [new Message("Message 1", Sender.Player), new Message("Message 2", Sender.GameMaster), new Message("This is a really really really really really really really really really really really really really really really really really really really really really really really really really really really really really really really really really really really really really really really really really really really really really really really really really really really really really really really really really really really really really really really really really really really really really really really long message.", Sender.Player)]);
#endif
        }

        /// <summary>
        /// Get names of open chats
        /// </summary>
        public List<string> GetChats() =>
            Chats.Select(k => k.Key).ToList();

        /// <summary>
        /// Get chat history with metadata for a given character from memory
        /// </summary>
        public List<Message> GetChatHistory(string characterName) =>
            Chats.FirstOrDefault(c => c.Key == characterName).Value ?? [];

        public void RegisterChat(string characterName)
        {
            if (Chats.ContainsKey(characterName))
                return;
            Chats.Add(characterName, []);
            _messageService.SendMessage(Constants.Topics.ChatAdded, characterName);
        }

        public void SendMessage(string characterName, string message, Sender sender)
        {
            if (!Chats.ContainsKey(characterName))
                throw new Exception($"PANIC!!!! THERE'S NO REGISTED CHAT FOR {characterName}");

            var chatHistory = GetChatHistory(characterName);

            chatHistory.Add(new Message(message, sender));

            if (sender == Sender.Player)
            {
                _messageService.SendMessage(Constants.Topics.PlayerMessage + characterName, message);
            } else
            {
                _messageService.SendMessage(Constants.Topics.GMPlayerMessage + characterName, message);
            }
        }
    }
}