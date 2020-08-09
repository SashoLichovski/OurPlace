function toggleUploadLink() {
    document.getElementById("toggleCoverForm").classList.remove("hide");
}

function dismissUploadLink() {
    document.getElementById("toggleCoverForm").classList.add("hide");
}

function toggleUploadForm(id) {
    var form = document.getElementById(id);
    if (form.classList.contains("hide")) {
        form.classList.remove("hide");
        form.classList.add("flex");
    } else {
        form.classList.remove("flex");
        form.classList.add("hide");
    }
}

var coverImage = document.getElementById("coverImage");
coverImage.addEventListener('click', function (event) {
    var body = document.getElementById("body");
    var container = document.createElement("div");
    container.classList.add("full");
    body.appendChild(container);

    var content = document.createElement("div");
    content.classList.add("content");
    container.appendChild(content);

    var img = document.createElement("img");
    img.src = event.target.src;
    img.style.width = "60%";
    img.style.left = "50%";
    img.style.margin = "auto";
    content.appendChild(img);

    container.style.cursor = "pointer";
    container.addEventListener("click", function () {
        container.remove();
    })
});