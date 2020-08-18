if (storageService.existsInLocalStorage("sidebar", "sidebar")) {
    document.getElementById("sidebar").style.left = "-270px";
}

function Toggle() {
    var sidebar = document.getElementById("sidebar");
    if (sidebar.style.left == "-270px") {
        sidebar.style.left = "0";
        storageService.removeFromLocalStorage(sidebar.id, "sidebar");
    } else {
        sidebar.style.left = "-270px";
        storageService.addToLocalStorage(sidebar.id, "sidebar");
    }
}

var friendsEle = document.getElementsByClassName("friend");
function searchFriends(event) {
    var value = event.target.value;
    for (var i = 0; i < friendsEle.length; i++) {
        if (!friendsEle[i].innerHTML.toLowerCase().includes(value.toLowerCase())) {
            friendsEle[i].classList.add("hide");
        } else {
            friendsEle[i].classList.remove("hide");
        }
    }
}
