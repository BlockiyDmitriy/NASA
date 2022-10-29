window.videoControls = {
    playVideo: function (videoByteArray) {
        playVideo(videoByteArray);
    },
}

function playVideo(videoByteArray) {
    var video = document.querySelector('video');
    video.src = URL.createObjectURL(videoByteArray);
    video.type = 'video/mp4'
    video.load();
    video.play();
}