
(function (cibertec) {
    cibertec.video = {

        play: function (videoId) {

            var videoElement = document.getElementById(videoId);

            videoElement.play();
        },

        pause: function (videoId) {

            var videoElement = document.getElementById(videoId);

            videoElement.pause();
        },

        stop: function (videoId) {

            var videoElement = document.getElementById(videoId);
            videoElement.currentTime = 0;
            videoElement.pause();
        }
    }
})(window.cibertec = window.cibertec || {});