using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Paranoia.Client.Services;
using System.ComponentModel.DataAnnotations;

namespace Paranoia.Client.Pages
{
    public class IndexModel(ILogger<IndexModel> _logger, IChatService _chatService) : PageModel
    {
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            _chatService.RegisterChat(CharacterName);

            return Redirect($"/PlayerChat/{CharacterName}");
        }

        [BindProperty, Required, RegularExpression(Constants.CharacterNameRegex)]
        public string CharacterName { get; set; }
    }
}
