function removeNot(id) {
    var ele = document.getElementById(`not-${id}`);
    ele.remove();

    axios.post(`/Notification/Delete/${id}`)
        .then(res => {
            console.log(res);
        })
        .catch(err => {
            console.log(err);
        })
}