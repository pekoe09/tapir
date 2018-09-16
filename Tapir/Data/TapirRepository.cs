using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tapir.Models
{
    public class TapirRepository<T> : ITapirRepository<T> where T : EntityBase
    {
        private readonly TapirContext context;

        public TapirRepository(TapirContext context)
        {
            this.context = context;
        }

        public T Add(T entity)
        {
            context.Set<T>().Add(entity);
            context.SaveChanges();
            return entity;
        }

        public T Edit(T entity)
        {
            throw new NotImplementedException();
        }

        public T FindById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> ListAll()
        {
            return context.Set<T>().AsEnumerable();
        }

        public T Remove(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
