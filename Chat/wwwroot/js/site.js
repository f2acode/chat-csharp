// Javascript related to messages.
let transportType = signalR.TransportType.WebSockets;
let httpMessage = new signalR.HttpConnection(`http://${document.location.host}/message`, { transport: transportType });
let connectionMessage = new signalR.HubConnection(httpMessage);
connectionMessage.start();

connectionMessage.on('Send', (nick, message) => {
    appendLine(nick, message);
});

document.getElementById('frm-send-message').addEventListener('submit', event => {
    let message = $('#message').val();
    let nick = $('#spn-nick').text();

    $('#message').val('');

    connectionMessage.invoke('Send', nick, message);
    event.preventDefault();
});

function appendLine(nick, message, color) {
    let nameElement = document.createElement('strong');
    nameElement.innerText = ` ${nick}:`;

    let msgElement = document.createElement('em');
    msgElement.innerText = ` ${message}`;

    let li = document.createElement('li');
    li.appendChild(nameElement);
    li.appendChild(msgElement);

    $('#messages').append(li);
};

function continueToChat() {
    $('#spn-nick').text($('#nick').val());
    $('#entrance').hide();
    $('#chat').show();
}

// Javascript related to chats
let httpChat = new signalR.HttpConnection(`http://${document.location.host}/chat`, { transport: transportType });
let connectionChat = new signalR.HubConnection(httpChat);
connectionChat.start();

connectionChat.on('NewChat', (nick, idChat) => {
    appendChat(nick, idChat);
});

function appendChat(nick, idChat) {

    var listChats = document.getElementById("chat-list");
    var newChat = document.createElement("LI");
    newChat.setAttribute("class", "left clearfix contact");
    newChat.setAttribute("data-idchat", idChat);

    newChat.innerHTML = "<div class=chat-body clearfix>" +
        "<div class=header_sec>" +
        "<strong class=primary-font>" +
        nick +
        "</strong>" +
        "</div>" +
        "<div class=contact_sec>" +
        "<span class=badge pull-right>Status atendimento</span>" +
        "</div>" +
        "</div>" +
        "</li>".trim();

    
    newChat.addEventListener('click', event => {
        let idChat = newChat.getAttribute("data-idchat");
        connectionChat.invoke('ChangeChat', idChat);
        event.preventDefault();
    });

    listChats.appendChild(newChat);
}

var contacts = Array.from(document.getElementsByClassName('contact'));

contacts.forEach(function (contact) {
    contact.addEventListener('click', event => {
        let idChat = contact.getAttribute("data-idchat");
        
        connectionChat.invoke('ChangeChat', idChat);
        event.preventDefault();
    });  
})

connectionChat.on('ChangeChat', (idChat, messages) => {
    changeMessages(idChat, messages);
});

function changeMessages(idChat, messages) {
    let messagesList = document.getElementById('messages-list');

    messages.forEach(function (message) {
        var newMessage = document.createElement("LI");
        newMessage.setAttribute("class", "left clearfix contact");
        newMessage.setAttribute("data-idMessage", idChat);

        newMessage.innerHTML = "<li class=left clearfix admin_chat>"+
            "<span class=chat-img1 pull-right>"
                "<img src="https://lh6.googleusercontent.com/-y-MY2satK-E/AAAAAAAAAAI/AAAAAAAAAJU/ER_hFddBheQ/photo.jpg" alt=User Avatar class=img-circle>"
                 "                       </span>
                "<div class="chat-body1 clearfix">
                    "<p>@m.Message</p>
                    "<div class="chat_time pull-left">09:40PM</div>
                "</div>
                 "                   </li >
        ".trim();

        messagesList.appendChild(newChat);
    })

    console.log("the current chat " + idChat);
    console.log(messages);
}