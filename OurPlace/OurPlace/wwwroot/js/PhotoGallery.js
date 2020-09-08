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

function toggleCarousel(imgIndex) {
    $(document.getElementById("body")).ready(function () {
        $('.single-item').slick({
            initialSlide: parseInt(imgIndex)
        });
    });

    var carousel = document.getElementById("carousel");
    carousel.classList.remove("hide");
    carousel.classList.add("full");

    document.addEventListener("keyup", function (event) {
        if (event.keyCode === 27) {
            carousel.classList.remove("full");
            carousel.classList.add("hide");
            $(document.getElementById("body")).ready(function () {
                $('.single-item').slick('unslick');
            });
        }
    })
}

function hideCarousel() {
    var carousel = document.getElementById("carousel");
    carousel.classList.remove("full");
    carousel.classList.add("hide");
    $(document.getElementById("body")).ready(function () {
        $('.single-item').slick('unslick');
    });
}

// PREVIOUS WAY OF GENERATING CAROUSEL FOR GALLERY PHOTOS -----------------------------------------
// THIS WILL NOT WORK BECAUSE ON SCROLLING IMAGES IT WILL ALWAYS SHOW COMMENTS AND LIKES ON THE FIRST IMAGE OPENED. TRY TO MAKE IT INSIDE THE VIEW WITH HIDE/SHOW.

//function scrollImages(event, likeCount, imageId, imageUserId, senderId) {
//    var images = document.getElementsByClassName("galleryImages");
//    var body = document.getElementById("body");
//    var arr = [].slice.call(images);
   

//    var container = document.createElement("div");
//    container.classList.add("full");
//    body.appendChild(container);

//    var carousel = document.createElement("div");
//    carousel.className = "single-item";
//    carousel.style.backgroundColor = "rgba(0, 0, 0, 0.7)";
//    carousel.style.width = "100%";
//    carousel.style.height = "100%";
//    container.appendChild(carousel);

//    var targetIndex = arr.indexOf(event.target); 
//    for (var i = targetIndex; i < images.length; i++) {
//        generateImg(i, carousel, images, likeCount, imageId, imageUserId, senderId);
//    }
//    for (var i = 0; i < targetIndex; i++) {
//        generateImg(i, carousel, images, likeCount, imageId, imageUserId, senderId);
//    }

//    var closeEle = document.createElement("i");
//    closeEle.className = "far fa-window-close";
//    closeEle.classList.add("closeCarousel");
//    container.appendChild(closeEle);

//    $(document.getElementById("body")).ready(function () {
//        $('.single-item').slick();
//    });

//    closeEle.addEventListener("click", function () {
//        container.remove();
//    });

//    document.addEventListener("keyup", function (event) {
//        if (event.keyCode === 27) {
//            container.remove();
//        }
//    })
//}

//function generateImg(i, carousel, images, likeCount, imageId, imageUserId, senderId) {
//    var imgContainer = document.createElement("div");
//    imgContainer.style.display = "flex";
//    imgContainer.style.justifyContent = "center";
//    carousel.appendChild(imgContainer);

//    var img = document.createElement("img");
//    img.src = images[i].src;
//    img.id = images[i].id;
//    img.style.height = "100%";
//    imgContainer.appendChild(img); 

//    var commentLikeContainer = document.createElement("div");
//    commentLikeContainer.style.width = "300px";
//    commentLikeContainer.style.height = "100%";
//    commentLikeContainer.style.backgroundColor = "white";
//    commentLikeContainer.style.overflow = "auto";
//    imgContainer.appendChild(commentLikeContainer);

//    var likeContainer = document.createElement("div");
//    likeContainer.style.padding = "15px";
//    likeContainer.style.display = "flex";
//    likeContainer.style.justifyContent = "center";
//    commentLikeContainer.appendChild(likeContainer);

//    var likeIcon = document.createElement("i");
//    likeIcon.className = "far fa-heart";
//    likeIcon.style.marginRight = "10px";
//    likeIcon.style.fontSize = "25px";
//    likeIcon.style.cursor = "pointer";
//    likeIcon.addEventListener("click", function () {
//        like(img.id, imageUserId, senderId, "image");
//        // Think for a logic how to display red icon if current user liked current image
//    });
//    likeContainer.appendChild(likeIcon);

//    var numberOfLikes = document.createElement("div");
//    numberOfLikes.innerText = `${likeCount} likes`;
//    numberOfLikes.style.fontSize = "20px";
//    numberOfLikes.style.marginLeft = "10px";
//    likeContainer.appendChild(numberOfLikes);

//    var commentContainer = document.createElement("div");
//    commentContainer.style.padding = "15px"
//    commentLikeContainer.appendChild(commentContainer);

//    var numberOfComments = document.createElement("div");
//    numberOfComments.innerText = "10 Comments";
//    commentContainer.appendChild(numberOfComments);

//    for (var i = 0; i < 10; i++) {
//        var comment = document.createElement("div");
//        comment.style.marginTop = "10px";
//        comment.style.paddingBottom = "5px";
//        comment.style.borderBottom = "1px solid rgba(0, 0, 0, 0.5)";
//        commentContainer.appendChild(comment);

//        var commentBy = document.createElement("div");
//        commentBy.innerText = "Sasho Lichovski";
//        comment.appendChild(commentBy);

//        var commentText = document.createElement("div");
//        commentText.style.padding = "5px";
//        commentText.innerText = `This is the comment text number ${i}`;
//        comment.appendChild(commentText);
//    }

//    var commentForm = document.createElement("form");
//    commentForm.style.position = "sticky";
//    commentForm.style.bottom = "0";
//    commentForm.style.padding = "5px";
//    commentLikeContainer.appendChild(commentForm);

//    var formInput = document.createElement("input");
//    formInput.className = "form-control";
//    formInput.placeholder = "Write something...";
//    formInput.style.background = "black";
//    formInput.style.color = "white";
//    commentForm.appendChild(formInput);
//}


