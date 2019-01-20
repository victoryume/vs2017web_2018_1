using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Repository.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity: class
    {

        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll(int id);
        int Count();
        
    }
}
