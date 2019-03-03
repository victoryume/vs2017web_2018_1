using App.Data.DataBase;
using App.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Repository
{
    public class AppUnitOfWork : IAppUnitOfWork
    {

        private readonly DbContext _context;        

        public ICategoriaRepository CategoriaRepository { get; set; }
        public IUnidadMedidaRepository UnidadMedidaRepository { get; set; }
        public IMarcaRepository MarcaRepository { get; set; }
        public IProductoRepository ProductoRepository { get; set; }
        public IUsuarioRepository UsuarioRepository { get; set; }
        public IComentarioRepository ComentarioRepository { get; set; }

        public AppUnitOfWork(DbContext context) {
            _context = context;
            CreateRepositories();
        }

        public AppUnitOfWork()
        {
            _context = new AppModel();
            CreateRepositories();
        }

        private void CreateRepositories(){
            this.CategoriaRepository = new CategoriaRepository(_context);
            this.UnidadMedidaRepository = new UnidadMedidaRepository(_context);
            this.MarcaRepository = new MarcaRepository(_context);
            this.ProductoRepository = new ProductoRepository(_context);
            this.UsuarioRepository = new UsuarioRepository(_context);
            this.ComentarioRepository = new ComentarioRepository(_context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
