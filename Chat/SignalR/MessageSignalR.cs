using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Chat.SignalR
{
    public class MessageSignalR : Hub
    {
        public async Task Send(string nick, string message)
        {
            await Clients.All.InvokeAsync("Send", nick, message);
        }        
    }
}
