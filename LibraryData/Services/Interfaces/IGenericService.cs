using System.Collections.Generic;

namespace LibraryData.Services.Interfaces
{
    public interface IGenericService<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();

        void Add(params TEntity[] entities);

        void Update(params TEntity[] entities);

        void SaveChanges();
    }
}

