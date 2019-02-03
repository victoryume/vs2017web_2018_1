﻿using App.Data.DataBase;
using App.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Repository
{
    public class AppUnitOfWork : IAppUnitOfWork, IDisposable
    {
        private readonly DbContext _context;

        public AppUnitOfWork()
        {
            _context = new AppModel();
            CrearRepositories();
        }

        public AppUnitOfWork(DbContext context)
        {
            _context = context;
            CrearRepositories();
        }

        private void CrearRepositories()
        {
            this.CategoriaRepository = new CategoriaRepository(_context);
            this.MarcaRepository = new MarcaRepository(_context);
            this.UnidadMedidaRepository = new UnidadMedidaRepository(_context);
            this.ProductoRepository = new ProductoRepository(_context);
        }

        public ICategoriaRepository CategoriaRepository { get; set; }
        public IMarcaRepository MarcaRepository { get; set; }
        public IUnidadMedidaRepository UnidadMedidaRepository { get; set; }
        public IProductoRepository ProductoRepository { get; set; }

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
