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
    //debugger;
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

function deletePost(postId) {
    if (confirm("Please confirm")) {
        document.getElementById(`postContainer-${postId}`).remove();

        axios.post(`/Post/DeletePost/${postId}`)
            .then(res => {

            })
            .catch(err => {
                console.log(err);
            })
    }
}

function toggleEditPost(postId) {
    var ele = document.getElementById(`editForm-${postId}`);
    if (ele.classList.contains("hide")) {
        ele.classList.remove("hide");
        ele.classList.add("editPostForm");
    } else {
        ele.classList.add("hide");
        ele.classList.remove("editPostForm");
    }
}

function editPost(event, postId) {
    event.preventDefault();

    var newMessage = document.getElementById(`editCommentInput-${postId}`).value;
    if (newMessage.trim() == "")
    {
        alert("You can't post empty message");
    }
    else
    {
        document.getElementById(`postMessage-${postId}`).innerText = newMessage;

        axios.post(`/Post/EditPost`, {
            postId: parseInt(postId),
            message: `${newMessage}`
        })
            .then(res => {

            })
            .catch(err => {
                console.log(err);
            })
        toggleEditPost(postId);
    }
}