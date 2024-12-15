using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Paranoia.Client.Enums;
using Paranoia.Client.Models;
using Paranoia.Client.Services;

namespace Paranoia.Client.Pages
{
    public class GMChatModel(IChatService _chatService) : PageModel
    {
        public IActionResult OnGet()
        {
            if (HttpContext.Connection.RemoteIpAddress?.ToString() != "127.0.0.1")
                return Redirect("https://www.youtube.com/watch?v=dQw4w9WgXcQ");

            Chats = _chatService.GetAllChatHistory();

            return Page();
        }

        public IActionResult OnPost(string character, string message)
        {
            if (string.IsNullOrWhiteSpace(message))
                return new NoContentResult();

            _chatService.SendMessage(character, message, Sender.GameMaster);

            Chats = _chatService.GetAllChatHistory();

            return new NoContentResult();
        }

        public IActionResult OnDelete(string characterName)
        {
            if (string.IsNullOrWhiteSpace(characterName))
                return new NoContentResult();

            _chatService.NukeChat(characterName);

            return new NoContentResult();
        }

        public Dictionary<string, List<Message>> Chats { get; set; }
    }
}
