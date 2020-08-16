//sidebar.style.left = "-270px";

function Toggle() {
    var sidebar = document.getElementById("sidebar");
    if (sidebar.style.left == "-270px") {
        sidebar.style.left = "0"
    } else {
        sidebar.style.left = "-270px"
    }
}