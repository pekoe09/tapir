using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tapir.Models
{
    public interface ITapirRepository<T> where T : EntityBase
    {
        IEnumerable<T> ListAll();
        T FindById(int id);
        T Add(T entity);
        T Edit(T entity);
        T Remove(T entity);
    }
}
