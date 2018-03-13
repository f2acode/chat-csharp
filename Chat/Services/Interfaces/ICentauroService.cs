using Chat.Models.Centauro;
using Chat.Models.Database;
using System.Collections.Generic;

namespace Chat.Services.Interfaces
{
    public interface ICentauroService
    {
        void CreateChat(ChatModel chat);
        ChatModel GetChat(string id);

        List<ChatDBModel> GetAllChats();
        List<MessageDBModel> GetMessages(string id);
    }
}
