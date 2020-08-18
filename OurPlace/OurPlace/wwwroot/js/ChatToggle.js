﻿// ------------------ Handling Chat window styles ------------------ //
// ------------------ Handling Chat window styles ------------------ //
var hiddenChats = storageService.getItems("hiddenChats");
for (var i = 0; i < hiddenChats.length; i++) {
    document.getElementById(`chat-${hiddenChats[i]}`).classList.add("hide");
    document.getElementById(`form-${hiddenChats[i]}`).classList.add("hide");
}

var chatIds = storageService.getItems("chats");
for (var i = 0; i < chatIds.length; i++) {
    var chat = document.getElementById(chatIds[i]);
    chat.classList.remove("hide");
    updateScroll(chatIds[i]);
}

// ------------------ Functions ------------------ //
// ------------------ Functions ------------------ //
function updateScroll(chatId) {
    var ele = document.getElementById(`chat-${chatId}`)
    ele.scrollTop = ele.scrollHeight;
}

function toggleChatBody(id) {
    var body = document.getElementById(`chat-${id}`)
    var input = document.getElementById(`form-${id}`)
    var header = document.getElementById(`header-${id}`)
    if (storageService.existsInLocalStorage(id, "chats")) {
        if (!body.classList.contains("hide")) {
            body.classList.add("hide");
            input.classList.add("hide");
            storageService.addToLocalStorage(id, "hiddenChats")
        } else {
            body.classList.remove("hide");
            input.classList.remove("hide");
            storageService.removeFromLocalStorage(id, "hiddenChats");
            updateScroll(id);
        }
    }
    if (header.style.backgroundColor == "rgb(23, 162, 184)") {
        header.style.backgroundColor = "#989898";
    }
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
    } else {
        chat.classList.add("hide");
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
    }
}