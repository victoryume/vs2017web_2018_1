(function (app) {

    app.ProductoView = {

        RefreshLista: function () {
            $("#filterByName").val("");
            $(".buscar").click();
            app.helpers.closeModal('ProductoCreatePopup');
        }
    }

})(window.app = window.app || {});