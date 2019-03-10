
(function (app) {

    app.ConsultaProductosStockView = {

        Init: function () {

            $(".ConsultaProductosStock .Buscar").on("click", this.Buscar);

            $("#ListaProductos").jsGrid(
                {
                    width: "100%",
                    height: "400px",
                    paging: true,
                    pageSize: 20,
                    pageIndex: 1,
                    sorting: true,
                    autoload: true,
                    pageLoading: true,
                    fields: [
                        { name: "ProductoCode", type: "text" },
                        { name: "Nombre", type: "text" },
                        { name: "CategoriaName", type: "text" },
                        { name: "MarcaName", type: "text" },
                        { name: "PrecioMayor", type: "text" },
                        { name: "PrecioMenor", type: "text" },
                        { name: "StockActual", type: "number" }
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
        },
        Buscar: function () {
            
            var filtros = {
                Nombre: $(".ConsultaProductosStock .Nombre").val(),
                Stock: $(".ConsultaProductosStock .Stock").val()
            }

            var grid = $("#ListaProductos").jsGrid("search", filtros);
                
        }
    }

})(window.app = window.app || {});