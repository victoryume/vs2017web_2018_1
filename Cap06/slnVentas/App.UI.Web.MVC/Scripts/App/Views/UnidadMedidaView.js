(function (app) {

    app.UnidadMedidaView = {

        RefreshLista: function () {
            $("#filterByName").val("");
            $(".buscar").click();
            app.helpers.closeModal('UnidadMedidaCreatePopup');            
        }
    }

})(window.app = window.app || {});