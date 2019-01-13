
(function (cibertec) {

    cibertec.helpers = {

        replaceAll: function (string, find, replace) {

            var resultado = string.replace(
                new RegExp(find, 'g'), replace
            );

            return resultado;
           
        },

        getAniosArray: function (anioInicio) {

            var hoy = new Date();
            var anios = [];

            for (i = anioInicio; i <= hoy.getFullYear(); i++) {

                anios.push(i);

            }

            return anios;

        },

        BloquearControles: function () {

            $('input, select, button, textarea').attr('disabled', 'disabled');

        },

        DesbloquearControles: function () {

            $('input, select, button, textarea').removeAttr('disabled', 'disabled');

        },

        SetObjetctLocalStorage: function (jsObject, keyStorage) {
            //stringify: SERIALIZA
            var objectString = JSON.stringify(jsObject);
            //ALMACENAR
            localStorage.setItem(keyStorage, objectString);

        },

        GetObjetctLocalStorage: function (keyStorage) {
            //parse: DESERIALIZA
            var objectString = localStorage.getItem(keyStorage);
            var objectJS = JSON.parse(objectString);
            
            return objectJS;

        }
               
    }
})(window.cibertec = window.cibertec || {});