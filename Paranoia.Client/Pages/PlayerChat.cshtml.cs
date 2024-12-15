using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Paranoia.Client.Models;
using Paranoia.Client.Services;
using System.Text.RegularExpressions;
using Paranoia.Client.Enums;

namespace Paranoia.Client.Pages
{
    public class PlayerChatModel(IChatService _chatService) : PageModel
    {
        public IActionResult OnGet()
        {
            if (!Regex.IsMatch(CharacterName, Constants.CharacterNameRegex))
                return Redirect("/");

            Messages = _chatService.GetChatHistory(CharacterName);

            return Page();
        }

        public IActionResult OnPost()
        {
            if (string.IsNullOrWhiteSpace(Message))
                return new NoContentResult();

            _chatService.SendMessage(CharacterName, Message, Sender.Player);

            Message = string.Empty;

            Messages = _chatService.GetChatHistory(CharacterName);

            return new NoContentResult();
        }

        [BindProperty(SupportsGet = true), FromRoute]
        public string CharacterName { get; set; }

        public List<Message> Messages { get; set; } = [];

        [BindProperty]
        public string Message { get; set; }
    }
}
