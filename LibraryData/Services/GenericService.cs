using LibraryData.Data.IRepositories;
using LibraryData.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace LibraryData.Services
{
    public abstract class GenericService<TEntity> : IGenericService<TEntity> where TEntity : class
    {
        protected readonly IGenericRepository<TEntity> Repository;
        public GenericService(IGenericRepository<TEntity> repository)
        {
            Repository = repository;
        }
        public void Add(params TEntity[] entities)
        {
            Repository.Add(entities);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Repository.GetAll();
        }

        public void SaveChanges()
        {
            Repository.SaveChanges();
        }

        public void Update(params TEntity[] entities)
        {
            Repository.Update(entities);
        }
    }
}
