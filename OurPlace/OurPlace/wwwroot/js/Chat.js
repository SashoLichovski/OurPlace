
function toggleChat(userId, friendId, chatName) {
    console.log(userId, friendId);
    //debugger;
    var chat = document.getElementById(userId + friendId);
    if (chat == null) {
        chat = document.getElementById(friendId + userId);
    }
    if (chat == null) {
        chat = document.getElementById(chatName);
    }
    if (chat.classList.contains("hide")) {
        chat.classList.remove("hide");
    } else {
        chat.classList.add("hide");
    }
    var textEle = document.getElementById(`chat-${userId + friendId}`);
    if (textEle == null) {
        textEle = document.getElementById(`chat-${friendId + userId}`);
    }
    textEle.scrollTop = textEle.scrollHeight;
}