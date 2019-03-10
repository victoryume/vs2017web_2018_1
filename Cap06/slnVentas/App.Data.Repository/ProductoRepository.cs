using App.Data.Repository.Interfaces;
using App.Entities.Base;
using App.Entities.Queries;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Repository
{
    public class ProductoRepository : GenericRepository<Producto>,IProductoRepository
    {

        public ProductoRepository(DbContext context):base(context){

        }

        public ListaPaginada<ProductoSearch> BuscarProductosStock(ProductoSearchFiltros filtros)
        {
            var result = new ListaPaginada<ProductoSearch>();
            filtros.Nombre = filtros.Nombre ?? "";

            //Para la paginación es necesario que se indique ordenamiento
            var query = from a in context.Set<Categoria>()
                        join b in context.Set<Producto>()
                        on a.CategoriaID equals b.CategoriaID
                        join c in context.Set<Marca>()
                        on b.MarcaID equals c.MarcaID
                        where b.Nombre.Contains(filtros.Nombre)
                        && b.StockActual > filtros.Stock
                        orderby a.Nombre
                        select new ProductoSearch()
                        {
                            ProductoID = b.ProductoID,
                            Nombre = b.Nombre,
                            CategoriaName = a.Nombre,
                            PrecioMayor = b.PrecioMayor,
                            PrecioMenor = b.PrecioMenor,
                            ProductoCode = b.ProductoCode,
                            StockActual = b.StockActual,
                            MarcaName = c.Nombre
                        };

            //Obtener la cantidad total de registros
            result.TotalRows = query.Count();
            //Paginar en el servidor
            //Toma el primer registro de la página seleccionada
            query = query.Skip(filtros.PageSize * (filtros.PageIndex - 1));
            //Toma los registros restantes según el tamaño de página
            query = query.Take(filtros.PageSize);

            result.Listado = query.ToList();

            return result;
        }
    }
}
