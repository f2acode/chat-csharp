using Chat.Models.Centauro;
using Chat.Models.Database;
using Chat.Models.ViewModel;
using Chat.Services.Interfaces;
using Chat.SignalR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Chat.Controllers
{
    public class CentauroController : Controller
    {
        ICentauroService _centauroService;
        public CentauroController(ICentauroService centauroService)
        {
            _centauroService = centauroService;
        }
        
        /* Todo:
         * perguntar sobre erros nas variáveis nos jsons
         * perguntar sobre traços nas chaves da api
         * 
         * **/

        [HttpPost]
        public IActionResult Chat([FromBody] ChatModel chat)
        {
            if (chat == null)
            {
                return BadRequest();
            }
            _centauroService.CreateChat(chat);

            return CreatedAtRoute("GetChat", new { Id = chat.ChatId }, chat);
        }

        [HttpGet("{id}", Name = "GetChat")]
        public ChatModel Chat(string id)
        {
            return _centauroService.GetChat(id);
        }

        [HttpPost]
        public IActionResult Msg_user([FromBody] ChatMessageCentauro chatMessage)
        {
            return NotFound();
        }

        [HttpPost]
        public IActionResult Msg_nutri([FromBody] ChatMessageTechfit chatMessage)
        {
            return NotFound();
        }

        [HttpPost]
        public IActionResult Msg_asset([FromBody] ChatAsset chatAsset)
        {
            return NotFound();
        }

        [HttpGet]
        //public List<ChatDBModel> ListChats()
        public IActionResult ChatList()
        {
            List<ChatViewModel> listChat = new List<ChatViewModel>();
            var chats = _centauroService.GetAllChats();

            foreach(var chat in chats)
            {
                ChatViewModel chatViewModel = new ChatViewModel
                {
                    Chat = chat,
                    Messages = _centauroService.GetMessages(chat.ChatIdCentauro)
                };
                listChat.Add(chatViewModel);
            }

            return View("Index", listChat);
        }
    }
}