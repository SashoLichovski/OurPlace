function toggleChatBody(id) {
    var body = document.getElementById(`chat-${id}`)
    var input = document.getElementById(`form-${id}`)
    if (!body.classList.contains("hide")) {
        body.classList.add("hide");
        input.classList.add("hide");
        storageService.addToLocalStorage(id, "hiddenChats")
    } else {
        body.classList.remove("hide");
        input.classList.remove("hide");
        storageService.removeFromLocalStorage(id, "hiddenChats")
    }
}

var hiddenChats = storageService.getItems("hiddenChats");
for (var i = 0; i < hiddenChats.length; i++) {
    document.getElementById(`chat-${hiddenChats[i]}`).classList.add("hide");
    document.getElementById(`form-${hiddenChats[i]}`).classList.add("hide");
}

var chatIds = storageService.getItems("chats");
var userIds = storageService.getItems("userIds");
for (var i = 0; i < chatIds.length; i++) {
    var chat = document.getElementById(chatIds[i]);
    chat.classList.remove("hide");
    chat.style.marginRight += `${(i * 320)}px`;
    toggleConnection(chat, userIds[i], false);
}

function toggleChat(userId, friendId) {
    //debugger;
    var chat = document.getElementById(userId + friendId);
    if (chat == null) {
        chat = document.getElementById(friendId + userId);
    }
    //debugger;
    // Displaying / Hiding chat , updating margin
    if (chat.classList.contains("hide")) {
        chat.classList.remove("hide");

        var textEle = document.getElementById(`chat-${userId + friendId}`);
        if (textEle == null) {
            textEle = document.getElementById(`chat-${friendId + userId}`);
        }
        textEle.scrollTop = textEle.scrollHeight;

        var openChats = storageService.getItems("chats");
        if (openChats.length > 0) {
            chat.style.marginRight = `${(openChats.length * 300) + (openChats.length * 20)}px`;
        }
    } else {
        chat.classList.add("hide");
        chat.style.marginRight = "0px";
    }
    
    //debugger;
    // Starting / Closing signalR connection, Updating local storage
    if (!storageService.existsInLocalStorage(chat.id, "chats")) {
        storageService.addToLocalStorage(chat.id, "chats");
        storageService.addToLocalStorage(userId, "userIds");
        toggleConnection(chat, userId, false);
    } else {
        storageService.removeFromLocalStorage(chat.id, "chats");
        storageService.removeFromLocalStorage(userId, "userIds");
        var openChats = storageService.getItems("chats");
        for (var i = 0; i < openChats.length; i++) {
            document.getElementById(openChats[i]).style.marginRight = `${(i * 300)+(i * 20)}px`;
        }
        toggleConnection(chat, userId, true);
    }

}


function toggleConnection(chat, userId, isStarted) {
    //debugger;
    var currentChat = chat;
    var chatText = document.getElementById(`chat-${currentChat.id}`);
    chatText.scrollTop = chatText.scrollHeight;

    var connection = new signalR.HubConnectionBuilder()
        .withUrl("/chatHub")
        .build();
    var _connectionId = "";
    //debugger;
    connection.on("ReceiveMessage", function (data) {

        if (data.userId == userId) {
            var div = document.createElement("div");
            div.style.marginBottom = "10px";
            chatText.appendChild(div);

            var msgContainer = document.createElement("div");
            msgContainer.classList.add("myMessageContainer");
            div.appendChild(msgContainer);

            var p = document.createElement("p");
            p.classList.add("bg-primary");
            p.innerText = data.text;
            msgContainer.appendChild(p);

            var img = document.createElement("img");
            img.classList.add("myMessageImg");
            img.src = `data:image/jpeg;base64,${data.userImage}`;
            msgContainer.appendChild(img);

            var dateSpan = document.createElement("div");
            dateSpan.classList.add("myDatePosted");
            dateSpan.innerText = data.datePosted;
            div.appendChild(dateSpan);
        } else {
            var div = document.createElement("div");
            div.style.marginBottom = "10px";
            chatText.appendChild(div);

            var msgContainer = document.createElement("div");
            msgContainer.classList.add("messageContainer");
            div.appendChild(msgContainer);

            var img = document.createElement("img");
            img.classList.add("messageImg");
            img.src = `data:image/jpeg;base64,${data.userImage}`;
            msgContainer.appendChild(img);

            var p = document.createElement("p");
            p.classList.add("bg-success");
            p.innerText = data.text;
            msgContainer.appendChild(p);

            var dateSpan = document.createElement("div");
            dateSpan.classList.add("datePosted");
            dateSpan.innerText = data.datePosted;
            div.appendChild(dateSpan);
        }

        chatText.scrollTop = chatText.scrollHeight;
    })

    var joinRoom = function () {
        axios.post(`/Chat/JoinRoom/${_connectionId}/${currentChat.id}`)
            .then(res => {
            })
            .catch(err => {
                console.log(err);
            })
    }

    var leaveRoom = function () {
        axios.post(`/Chat/LeaveRoom/${_connectionId}/${currentChat.id}`)
            .then(res => {
            })
            .catch(err => {
                console.log(err);
            })
    }

    connection.start()
        .then(function () {
            connection.invoke("getConnectionId")
                .then(function (connectionId) {
                    //debugger;
                    var connectionObject = {
                        chatId: currentChat.id,
                        connectionId: connectionId
                    }
                    if (storageService.existsInLocalStorage(currentChat.id, "chats")) {
                        storageService.addToLocalStorage(connectionObject, "connectionIds")
                        _connectionId = connectionId
                    }
                    else
                    {
                        var connectionItems = storageService.getItems("connectionIds");
                        for (var i = 0; i < connectionItems.length; i++) {
                            if (connectionItems[i].chatId == currentChat.id) {
                                _connectionId = connectionItems[i].connectionId;
                                storageService.removeFromLocalStorage(connectionItems[i], "connectionIds");
                            }
                        }
                    }

                    if (isStarted)
                    {
                        leaveRoom();
                    }
                    else
                    {
                        joinRoom();
                    }
                })
        })
        .catch(function (err) {
            console.log(err);
        });
    


}

function sendMessage(event, chatTextId) {
    event.preventDefault();
    console.log()
    var data = new FormData(event.target);

    axios.post("/Chat/SendMessage", data)
        .then(res => {
            document.getElementById(`input-${chatTextId}`).value = "";
            var textBox = document.getElementById(`chat-${chatTextId}`).value = "";
            textBox.scrollTop = textBox.scrollHeight;
        })
        .catch(err => {
            console.log(err);
        })
}