(function (app) {

    app.MarcaView = {

        RefreshLista: function () {
            $("#filterByName").val("");
            $(".buscar").click();
            app.helpers.closeModal('MarcaCreatePopup');            
        }
    }

})(window.app = window.app || {});