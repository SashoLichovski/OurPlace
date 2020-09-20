function validateInput(inputId, btnId) {
    var inputValue = document.getElementById(inputId).value;
    var btn = document.getElementById(btnId);
    if (inputValue == "") {
        btn.disabled = true;
    } else {
        btn.disabled = false;
    }
}

function searchTable(event) {
    var friendRows = document.getElementsByClassName("friendRow");
    for (var i = 0; i < friendRows.length; i++) {
        if (friendRows[i].firstElementChild.innerHTML.toLowerCase().includes(event.target.value.toLowerCase())) {
            friendRows[i].classList.remove('hide');
        } else {
            friendRows[i].classList.add('hide');
        }
    }
}