using App.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : class
    {

        protected readonly DbContext context;

        public GenericRepository(DbContext context)
        {
            this.context = context;
        }

        public void Add(TEntity entity)
        {
            this.context.Set<TEntity>().Add(entity);
        }

        public int Count()
        {
            return this.context.Set<TEntity>().Count();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="includes"></param>
        /// <returns></returns>        
        public IEnumerable<TEntity> GetAll(
            Expression<Func<TEntity, bool>> predicate = null,
            string includes = null)
        {
            var result = new List<TEntity>();

            IQueryable<TEntity> query = this.context.Set<TEntity>();

            if (includes != null)
            {

                foreach (var tableInclude in includes.Split(','))
                {
                    query = query.Include(tableInclude);
                }
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return query.ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TEntity GetById(int id)
        {
            return this.context.Set<TEntity>().Find(id);
        }

        public void Remove(TEntity entity)
        {
            this.context.Set<TEntity>().Attach(entity);
            this.context.Set<TEntity>().Remove(entity);
        }

        public void Update(TEntity entity)
        {
            this.context.Set<TEntity>().Attach(entity);
            this.context.Entry<TEntity>(entity).State = EntityState.Modified;
        }

    }
}
