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

function deleteComment(commentId, postId) {
    document.getElementById(`commentContent-${commentId}`).remove();
    var count = document.getElementById(`commentNo-${postId}`);
    var number = parseInt(count.innerText[0] + count.innerText[1]);
    number--;
    console.log(number);
    count.innerText = `${number} Comments`;

    axios.post(`/Comment/DeleteComment/${commentId}`)
        .then(res => {

        })
        .catch(err => {
            console.log(err);
        })
}