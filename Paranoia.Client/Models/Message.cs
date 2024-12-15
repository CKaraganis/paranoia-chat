using Paranoia.Client.Enums;

namespace Paranoia.Client.Models
{
    public class Message
    {
        public Guid Id { get; set; }
        public string? Contents { get; set; }
        public Sender Sender { get; set; }
        public DateTime Timestamp { get; set; }
        public DateTime Opened { get; set; }

        public Message(string contents, Sender sender)
        {
            Id = Guid.NewGuid();
            Contents = contents;
            Sender = sender;
            Timestamp = DateTime.Now;
            if (sender == Sender.GameMaster)
            {
                Opened = DateTime.Now;
            }
        }
    }
}
