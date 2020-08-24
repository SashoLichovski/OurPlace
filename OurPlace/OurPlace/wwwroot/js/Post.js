function togglePostFileInput() {
    var ele = document.getElementById("postFileInput");
    if (ele.classList.contains("hide")) {
        ele.classList.remove("hide");
    } else {
        ele.classList.add("hide");
    }
}

function toggleComments(id) {
    var ele = document.getElementById(`commentContainer-${id}`);
    if (ele.classList.contains("hide")) {
        ele.classList.remove("hide");
    } else {
        ele.classList.add("hide");
    }
}