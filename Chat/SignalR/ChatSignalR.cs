using Chat.Models.Database;
using Chat.Services.Concretes;
using Chat.Services.Interfaces;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chat.SignalR
{
    public class ChatSignalR : Hub
    {
        ICentauroService _centauroService;
        public ChatSignalR(ICentauroService centauroService)
        {
            _centauroService = centauroService;
        }
        public async Task NewChat(string nick, string idChat)
        {
            await Clients.All.InvokeAsync("NewChat", nick, idChat);
        }
        
        public async Task ChangeChat(string idChat)
        {
            List<MessageDBModel> messages = _centauroService.GetMessages(idChat);
            await Clients.All.InvokeAsync("ChangeChat", idChat, messages);
        }
    }
}
