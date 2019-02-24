(function (app) {

    app.CategoriaView = {

        RefreshLista: function () {
            $("#filterByName").val("");
            $(".buscar").click();
            app.helpers.closeModal('CategoriaCreatePopup');            
        }
    }

})(window.app = window.app || {});