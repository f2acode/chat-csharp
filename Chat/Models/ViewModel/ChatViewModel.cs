using Chat.Models.Database;
using System.Collections.Generic;

namespace Chat.Models.ViewModel
{
    public class ChatViewModel
    {
        public ChatDBModel Chat { get; set; }
        public List<MessageDBModel> Messages { get; set; }
    }
}
