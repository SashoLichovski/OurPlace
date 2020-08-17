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
        //debugger;
        var friendEle = document.getElementById(`friend-${currentChatName}`);
        friendEle.style.backgroundColor = "red";
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
