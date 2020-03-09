using BosaApi.Teste.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BosaApi.Teste.Models.Templates
{
    public abstract class PublicRepository<T> : IPublicRepository<T>
    {
        public virtual Task<IEnumerable<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public virtual Task<T> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public virtual Task SaveAsync(T model)
        {
            throw new NotImplementedException();
        }
    }
}

