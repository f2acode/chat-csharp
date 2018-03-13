using Chat.Models.Centauro.Partials;

namespace Chat.Models.Centauro
{
    public class ChatMessageTechfit
    {
        public string Operation { get; set; }
        public string Partner { get; set; }
        public PayloadChatMessageTechFit Payload { get; set; }
    }
}
