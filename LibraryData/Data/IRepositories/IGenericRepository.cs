using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryData.Data.IRepositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();

        void Add(params TEntity[] entities);

        TEntity Add(TEntity entity);

        void Update(params TEntity[] entities);

        void SaveChanges();
    }
}
