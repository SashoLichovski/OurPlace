function toggleUploadLink() {
    document.getElementById("toggleCoverForm").classList.remove("hide");
}

function dismissUploadLink() {
    document.getElementById("toggleCoverForm").classList.add("hide");
}

function toggleUploadForm() {
    var form = document.getElementById("coverForm");
    if (form.classList.contains("hide")) {
        form.classList.remove("hide");
        form.classList.add("flex");
    } else {
        form.classList.remove("flex");
        form.classList.add("hide");
    }
}