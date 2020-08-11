var gallery = document.querySelector('#gallery');

var getVal = function (elem, style) { return parseInt(window.getComputedStyle(elem).getPropertyValue(style)); };

var getHeight = function (item) { return item.querySelector('.content').getBoundingClientRect().height; };

var resizeAll = function () {
    var altura = getVal(gallery, 'grid-auto-rows');
    var gap = getVal(gallery, 'grid-row-gap');
    gallery.querySelectorAll('.gallery-item').forEach(function (item) {
        var el = item;
        el.style.gridRowEnd = "span " + Math.ceil((getHeight(item) + gap) / (altura + gap));
    });
};

gallery.querySelectorAll('img').forEach(function (item) {
    item.addEventListener('loadstart', function () {
            var altura = getVal(gallery, 'grid-auto-rows');
            var gap = getVal(gallery, 'grid-row-gap');
            var gitem = item.parentElement.parentElement;
            gitem.style.gridRowEnd = "span " + Math.ceil((getHeight(gitem) + gap) / (altura + gap));
        });
});

window.addEventListener('load', resizeAll);

//gallery.querySelectorAll('.gallery-item').forEach(function (item) {
//    item.addEventListener('click', function () {
//        item.classList.toggle('full');
//    });
//});

function scrollImages(event) {
    var images = document.getElementsByClassName("galleryImages");
    var body = document.getElementById("body");
    var arr = [].slice.call(images);
   

    var container = document.createElement("div");
    container.classList.add("full");
    body.appendChild(container);

    var carousel = document.createElement("div");
    carousel.className = "single-item";
    carousel.style.backgroundColor = "rgba(0, 0, 0, 0.7)";
    carousel.style.width = "100%";
    carousel.style.height = "100%";
    container.appendChild(carousel);

    var targetIndex = arr.indexOf(event.target); 
    for (var i = targetIndex; i < images.length; i++) {
        var img = document.createElement("img");
        img.src = images[i].src;
        carousel.appendChild(img);
    }
    for (var i = 0; i < targetIndex; i++) {
        var img = document.createElement("img");
        img.src = images[i].src;
        carousel.appendChild(img);
    }

    var closeEle = document.createElement("i");
    closeEle.className = "far fa-window-close";
    closeEle.classList.add("closeCarousel");
    container.appendChild(closeEle);

    $(document.getElementById("body")).ready(function () {
        $('.single-item').slick();
    });

    closeEle.addEventListener("click", function () {
        container.remove();
    });
}


