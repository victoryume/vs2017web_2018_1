
(function (cibertec) {
    cibertec.video = {

        play: function (videoId) {

            var videoElement = document.getElementById(videoId);

            videoElement.play();
        }
    }
})(window.cibertec = window.cibertec || {});