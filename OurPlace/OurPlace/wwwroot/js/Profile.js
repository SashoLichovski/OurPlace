function toggleUploadLink() {
    document.getElementById("toggleCoverForm").classList.remove("hide");
}

function dismissUploadLink() {
    document.getElementById("toggleCoverForm").classList.add("hide");
}

function toggleUploadForm(id) {
    if (id == "imageSettings") {
        var elems = document.getElementsByClassName("gallery-item full");
        for (var i = 0; i < elems.length; i++) {
            elems[i].classList.remove("full");
        }
    }
    var form = document.getElementById(id);
    if (form.classList.contains("hide")) {
        form.classList.remove("hide");
        form.classList.add("flex");
    } else {
        form.classList.remove("flex");
        form.classList.add("hide");
    }
}

function toggleImageSetting(event) {
    var btn = document.getElementById("imageSettingsBtn");
    btn.disabled = true;
    var imageId = event.target.id
    var ele = document.getElementById("imageSettings");
    if (ele.classList.contains("hide")) {
        ele.classList.remove("hide");
        ele.classList.add("flex");
    } else {
        ele.classList.remove("flex");
        ele.classList.add("hide");
    }
    document.getElementById('hiddenInput').value = imageId;
    document.getElementById('deleteInput').value = imageId;
}

function checkSelectInput() {
    var input = document.getElementById("photoType");
    var btn = document.getElementById("imageSettingsBtn");
    if (input.value != "Select") {
        btn.disabled = false;
    } else {
        btn.disabled = true;
    }
}

function openPhoto() {
    var body = document.getElementById("body");
    var container = document.createElement("div");
    container.classList.add("full");
    body.appendChild(container);

    var content = document.createElement("div");
    content.classList.add("content");
    container.appendChild(content);

    var img = document.createElement("img");
    img.src = event.target.src;
    img.id = "layoutPhoto";
    content.appendChild(img);

    container.style.cursor = "pointer";
    container.addEventListener("click", function () {
        container.remove();
    })
}

