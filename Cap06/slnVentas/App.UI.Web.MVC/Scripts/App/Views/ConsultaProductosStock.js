
(function (app) {

    app.ConsultaProductosStockView = {

        Init: function () {
            $("#ListaProductos").jsGrid(
                {
                    width: "100%",
                    height: "400px",
                    paging: true,
                    pageSize: 4,
                    pageIndex: 1,
                    autoload: true,
                    pageLoading: true,
                    fields: [
                        { name: "Nombre", type: "text", width: 150 },
                        { name: "StockActual", type: "number", width: 150 }
                    ],

                    controller:
                        {
                            loadData: function (filter) {

                                var d = $.Deferred(); //Resultado diferido

                                $.ajax(
                                    {
                                        url: "/Producto/BuscarProductosStock",
                                        data: filter,
                                        dataType: "json"
                                    }
                                ).done(
                                    function (response) {
                                        
                                            var data =  {
                                                data: response.Listado, itemsCount: response.TotalRows
                                            }

                                            d.resolve(data);
                                        }
                                );

                                //Resultado diferido
                                return d.promise();

                            }
                        }
                }
            );
        }
    }

})(window.app = window.app || {});