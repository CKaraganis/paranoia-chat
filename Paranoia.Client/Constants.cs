namespace Paranoia.Client
{
    public class Constants
    {
        public const string CharacterNameRegex = @"\S+[-]\S[-]\S{3}";

        public class Topics
        {
            public const string ChatAdded = "paranoia/chat/added";

            public const string PlayerMessage = "paranoia/chat/player/";
            public const string GMPlayerMessage = "paranoia/chat/gm/";
        }
    }
}
