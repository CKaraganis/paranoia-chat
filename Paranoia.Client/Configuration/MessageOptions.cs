using System.ComponentModel.DataAnnotations;

namespace Paranoia.Client.Configuration
{
    public class MessageOptions
    {
        [Required]
        public string HostName { get; set; } = null!;
        public int Port { get; set; }

        
        public string Host => $"{HostName}:{Port}"; 
    }
}
