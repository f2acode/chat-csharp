using Chat.Contexts;
using Chat.Models.Centauro;
using Chat.Models.Database;
using Chat.Services.Interfaces;
using Chat.SignalR;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.Services.Concretes
{
    public class CentauroService : Hub, ICentauroService
    {
        private readonly InMemoryContext _context;
        private IHubContext<ChatSignalR> HubContext { get; set; }

        public CentauroService(InMemoryContext context, IHubContext<ChatSignalR> hubcontext)
        {
            HubContext = hubcontext;
            _context = context;

            if (_context.Chats.Count() == 0)
            {
                _context.Chats.Add(new ChatDBModel { ChatIdCentauro = "1", CreatedAt = 1, UserName = "Juliana" });
                _context.Messages.Add(new MessageDBModel { ChatId = "1", Message = "Oi, eu tenho uma dúvida", IsInternalUser = false });
                _context.Messages.Add(new MessageDBModel { ChatId = "1", Message = "Oi, eu tenho uma dúvida", IsInternalUser = false });
                _context.Messages.Add(new MessageDBModel { ChatId = "1", Message = "Pode falar", IsInternalUser = true });

                _context.Chats.Add(new ChatDBModel { ChatIdCentauro = "2", CreatedAt = 1, UserName = "João" });
                _context.Messages.Add(new MessageDBModel { ChatId = "2", Message = "Oi, eu tenho uma dúvida", IsInternalUser = false });
                _context.Messages.Add(new MessageDBModel { ChatId = "2", Message = "Oi, eu tenho uma dúvida", IsInternalUser = false });
                _context.Messages.Add(new MessageDBModel { ChatId = "2", Message = "Pode falar", IsInternalUser = true });

                _context.SaveChanges();
            }
        }

        public void CreateChat(ChatModel chat)
        {
            _context.Chats.Add(
                new ChatDBModel { ChatIdCentauro = chat.ChatId, CreatedAt = chat.CreatedAt, UserName = chat.Name });

            Update(chat.Name, chat.ChatId);

            _context.SaveChanges();
        }

        public async Task Update(string name, string idChat)
        {
            await this.HubContext.Clients.All.InvokeAsync("NewChat", name, idChat);
        }

        public ChatModel GetChat(string id)
        {
            var chatDBModel = _context.Chats.FirstOrDefault(p => p.ChatIdCentauro == id);

            ChatModel chatModel = new ChatModel
            {
                ChatId = chatDBModel.ChatIdCentauro,
                CreatedAt = chatDBModel.CreatedAt,
                Name = chatDBModel.UserName
            };

            return chatModel;
        }

        public List<ChatDBModel> GetAllChats()
        {
            return _context.Chats.ToList();
        }

        public List<MessageDBModel> GetMessages(string id)
        {
            return _context.Messages.Where(m => m.ChatId == id).ToList();
        }
    }
}
