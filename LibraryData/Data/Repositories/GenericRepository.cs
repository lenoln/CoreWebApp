using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace LibraryData.Data.Repositories
{
    public abstract class GenericRepository<TEntity> where TEntity : class
    {
        protected readonly LibraryContext Context;

        public GenericRepository(LibraryContext dbContext)
        {
            Context = dbContext;
        }

        public virtual void Add(params TEntity[] toAdd)
        {
            Context.Set<TEntity>().AddRange(toAdd);
        }

        public virtual TEntity Add(TEntity toAdd)
        {
            return Context.Set<TEntity>().Add(toAdd).Entity;
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return Context.Set<TEntity>();
        }

        public virtual void Update(params TEntity[] toUpdate)
        {
            foreach (var item in toUpdate)
            {
                Context.Entry(item).State = EntityState.Modified;
            }
        }

        public virtual void DeleteAll()
        {
            foreach (var obj in Context.Set<TEntity>())
            {
                Context.Set<TEntity>().Remove(obj);
            }
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }
    }
}
