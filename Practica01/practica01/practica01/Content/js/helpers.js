
(function (cibertec) {

    cibertec.helpers = {

        
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

		},

		soloNumeros: function (e) {
			key = e.keyCode || e.which;
			teclado = String.fromCharCode(key).toLowerCase();
			numeros = ".1234567890";
			especiales = "8-37-38-46"; // Teclas especiales para ejecutarse
			/*
			8: backspace
			37: tecla izquierda
			38: tecla derecha
			46: suprimir
			*/
			teclado_epecial = false;

			for (var i in especiales) {
				if (key == especiales[i]) {//si el key es igual a los especiale spermitidos
					teclado_epecial = true; break;
				}
			}

			if (numeros.indexOf(teclado) == -1 && !teclado_epecial) {
				return false; //no aceptará el caracter(no dejará escribir)
			}
		}
               
    }
})(window.cibertec = window.cibertec || {});