// ------------------ Handling Chat window styles ------------------ //
// ------------------ Handling Chat window styles ------------------ //
function updateScroll(chatId) {
    var ele = document.getElementById(`chat-${chatId}`)
    ele.scrollTop = ele.scrollHeight;
}

function toggleChatBody(id) {
    var body = document.getElementById(`chat-${id}`)
    var input = document.getElementById(`form-${id}`)
    if (storageService.existsInLocalStorage(id, "chats")) {
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
}

var hiddenChats = storageService.getItems("hiddenChats");
for (var i = 0; i < hiddenChats.length; i++) {
    //if (storageService.existsInLocalStorage(hiddenChats[i], "chats")) {
        document.getElementById(`chat-${hiddenChats[i]}`).classList.add("hide");
        document.getElementById(`form-${hiddenChats[i]}`).classList.add("hide");
    //}
}

var chatIds = storageService.getItems("chats");
for (var i = 0; i < chatIds.length; i++) {
    var chat = document.getElementById(chatIds[i]);
    chat.classList.remove("hide");
    chat.style.marginRight += `${(i * 320)}px`;
    updateScroll(chatIds[i]);
}

function toggleChat(userId, friendId) {
    //debugger;
    var chat = document.getElementById(userId + friendId);
    if (chat == null) {
        chat = document.getElementById(friendId + userId);
    }

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
    // Updating local storage
    if (!storageService.existsInLocalStorage(chat.id, "chats")) {
        storageService.addToLocalStorage(chat.id, "chats");
    } else {
        storageService.removeFromLocalStorage(chat.id, "chats");
        if (storageService.existsInLocalStorage(chat.id, "hiddenChats")) {
            storageService.removeFromLocalStorage(chat.id, "hiddenChats");
            document.getElementById(`chat-${chat.id}`).classList.remove("hide");
            document.getElementById(`form-${chat.id}`).classList.remove("hide");
        }
        var openChats = storageService.getItems("chats");
        for (var i = 0; i < openChats.length; i++) {
            document.getElementById(openChats[i]).style.marginRight = `${(i * 300)+(i * 20)}px`;
        }
    }
}


// ------------------ SignalR Connection and Functions ------------------ //
// ------------------ SignalR Connection and Functions ------------------ //
var chats = document.getElementsByClassName("chatContainer");
var userIds = document.getElementsByClassName("hiddenUserId");
for (var i = 0; i < chats.length; i++) {
    //debugger;
    setTimeout(setConnections(chats[i].id, userIds[0].id), 100)
}

function setConnections(chatId, userId){

    var currentChatName = chatId;

    var chatText = document.getElementById(`chat-${currentChatName}`);
    //var startTime = new Date().getMilliseconds();
    var connection = new signalR.HubConnectionBuilder()
        .withUrl("/chatHub")
        .build();
    var _connectionId = "";

    var joinRoom = function () {
        axios.post(`/Chat/JoinRoom/${_connectionId}/${currentChatName}`)
            .then(res => {
                console.log(`JoinRoom works ${currentChatName}`)
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
                    _connectionId = connectionId
                    console.log(`This is connected ${_connectionId}`)
                    joinRoom();
                })
        })
        .catch(function (err) {
            console.log(err);
        });
    //debugger;
    var userId = userId;
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
    //var endTime = new Date().getMilliseconds();
    //console.log(endTime - startTime);
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
