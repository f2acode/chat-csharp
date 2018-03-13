using Chat.Models.Centauro.Partials;

namespace Chat.Models.Centauro
{
    public class ChatAsset
    {
        public string Operation { get; set; }
        public string Partner { get; set; }
        public PayloadChatAsset Payload { get; set; }
    }
}