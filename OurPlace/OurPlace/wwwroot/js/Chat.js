// ------------------ SignalR Connections------------------ //
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
                storageService.addToLocalStorage(currentChatName, "connectionNames");
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
        friendEle.style.backgroundColor = "#17a2b8";
        chatText.scrollTop = chatText.scrollHeight;
        friendEle.addEventListener("mouseover", function () {
            friendEle.style.backgroundColor = "rgb(191, 207, 0)";
            friendEle.style.color = "rgb(35, 35, 35)";
        });
        friendEle.addEventListener("mouseout", function () {
            friendEle.style.backgroundColor = "#343a40";
            friendEle.style.color = "whitesmoke";
        });

        if (storageService.existsInLocalStorage(currentChatName, "hiddenChats")) {
            var chatHeader = document.getElementById(`header-${currentChatName}`);
            chatHeader.style.backgroundColor = "#17a2b8";
        }

        var chatEle = document.getElementById(currentChatName);
        chatEle.classList.remove("hide");
        chatText.scrollTop = chatText.scrollHeight;
        if (!storageService.existsInLocalStorage(currentChatName, "chats")) {
            storageService.addToLocalStorage(currentChatName, "chats");
        }
    })

    connection.on("ReceiveLike", function (data) {
        sendNotification(data);
    })

    connection.on("ReceivePostComment", function (data) {

        var container = document.getElementById(`commentContainer-${data.postId}`);

        var commentContainer = document.createElement("div");
        commentContainer.classList.add("commentContent");
        commentContainer.id = `commentContent-${data.commentId}`;
        container.appendChild(commentContainer);

        var userName = document.createElement("span");
        userName.innerText = data.sentBy;
        commentContainer.appendChild(userName);

        var message = document.createElement("p");
        message.innerText = data.message;
        commentContainer.appendChild(message);

        // test start
        var commentInfo = document.createElement("div");
        commentInfo.classList.add("postInfo");
        commentContainer.appendChild(commentInfo);

        var commentLikes = document.createElement("div");
        commentLikes.classList.add("postLikes");
        commentInfo.appendChild(commentLikes);

        var likeIcon = document.createElement("a");
        likeIcon.id = `commentLike-${data.commentId}`;
        likeIcon.className = "far fa-heart";
        likeIcon.addEventListener("click", function () {
            like(data.commentId, data.userId, data.friendId, "comment");
            if (likeIcon.style.color == "red") {
                likeIcon.style.color = "black";
                likeCount.innerText = "0 likes";
            } else {
                likeIcon.style.color = "red";
                likeCount.innerText = "1 likes";
            }
        });
        commentLikes.appendChild(likeIcon);

        var likeCount = document.createElement("div");
        likeCount.id = `commentCount-${data.postId}`;
        likeCount.innerText = "0 likes";
        commentLikes.append(likeCount);

        var dateSent = document.createElement("span");
        dateSent.classList.add("postDate");
        dateSent.innerText = data.dateSent;
        commentInfo.appendChild(dateSent);

        var count = document.getElementById(`commentNo-${data.postId}`);
        var number = parseInt(count.innerText[0] + count.innerText[1]);
        number++;
        count.innerText = `${number} Comments`;
        document.getElementById(`commentContainer-${data.postId}`).classList.remove("hide");

        var deleteBtn = document.createElement("div");
        deleteBtn.classList.add("deleteBtn");
        deleteBtn.classList.add("text-danger");
        deleteBtn.innerText = "Delete";
        deleteBtn.addEventListener("click", function () {
            deleteComment(data.commentId, data.postId);
        });
        commentContainer.appendChild(deleteBtn);

        sendNotification(data);

    })
}


// ------------------ Functions ------------------ //

function sendNotification(data) {
    if (data.userId != data.friendId) {
        var container = document.getElementById(`notContainer-${data.friendId}`);
        if (container != undefined) {
            var msgContainer = document.createElement("div");
            msgContainer.style.padding = "15px";
            msgContainer.style.margin = "15px";
            msgContainer.style.borderRadius = "10px";
            msgContainer.style.backgroundColor = "rgba(0, 0, 0, 0.8)";
            msgContainer.style.zIndex = "50";
            container.appendChild(msgContainer);

            var close = document.createElement("i");
            close.className = "far fa-window-close";
            close.style.color = "white";
            close.style.cursor = "pointer";
            close.addEventListener("click", function () {
                msgContainer.remove();
            });
            msgContainer.appendChild(close);

            var message = document.createElement("div");
            message.innerText = data.notification.message;
            message.style.color = "white";
            msgContainer.appendChild(message);
        }
    }
}

function sendMessage(event, chatTextId) {
    event.preventDefault();
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

function like(entityId, friendId, senderId, likeType) {
    //debugger;
    var connections = storageService.getItems("connectionNames");
    var connectionName = "";
    for (var i = 0; i < connections.length; i++) {
        if (connections[i].includes(friendId) && connections[i].includes(senderId)) {
            connectionName = connections[i];
            break;
        }
    }
    axios.post(`/Like/EntityLike/${entityId}/${connectionName}/${friendId}/${likeType}`)
        .then(res => {
            var heart = document.getElementById(`${likeType}Like-${entityId}`);
            var count = document.getElementById(`${likeType}Count-${entityId}`);
            var number = parseInt(count.innerText[0] + count.innerText[1]);
            if (heart.style.color == "red") {
                heart.style.color = "black";
                number--;
                count.innerText = `${number} likes`;
            } else {
                heart.style.color = "red";
                number++;
                count.innerText = `${number} likes`;
            }
            console.log("First Time !!!!");
        })
        .catch(err => {
            console.log(err);
        });

    
}

function comment(event, postId, friendId, senderId) {
    event.preventDefault();
    var connections = storageService.getItems("connectionNames");
    var connectionName = "";
    for (var i = 0; i < connections.length; i++) {
        if (connections[i].includes(friendId) && connections[i].includes(senderId)) {
            connectionName = connections[i];
            break;
        }
    }
    var message = document.getElementById(`commentInput-${postId}`).value;

    if (message.trim() == "") {
        alert("You can't send empty comment");
    }
    else {
        axios.post(`/Comment/PostComment/${postId}/${connectionName}/${friendId}/${message}`)
            .then(res => {

            })
            .catch(err => {
                //console.log(err);
            })
    }
    document.getElementById(`commentInput-${postId}`).value = "";
}