function like(postId, friendId, senderId, likeType) {
    //debugger;
    var connections = storageService.getItems("connectionNames");
    var connectionName = "";
    for (var i = 0; i < connections.length; i++) {
        if (connections[i].includes(friendId) && connections[i].includes(senderId)) {
            connectionName = connections[i];
            break;
        }
    }
    axios.post(`/Like/EntityLike/${postId}/${connectionName}/${friendId}/${likeType}`)
        .then(res => {

        })
        .catch(err => {
            console.log(err);
        })

    var heart = document.getElementById(`${likeType}Like-${postId}`);
    var count = document.getElementById(`${likeType}Count-${postId}`);
    var number = parseInt(count.innerText[0] + count.innerText[1]); // TUKA NE RABOTI NA COMMENT LIKE !!!
    if (heart.style.color == "red") {
        heart.style.color = "black";
        number--;
        count.innerText = `${number} likes`;
    } else {
        heart.style.color = "red";
        number++;
        count.innerText = `${number} likes`;
    }
}
