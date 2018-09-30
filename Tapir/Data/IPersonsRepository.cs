using System.Collections.Generic;

namespace Tapir.Models
{
    public interface IPersonsRepository
    {
        IEnumerable<Person> GetAll();
        Person GetById(int id);
        Person Insert(Person entity);
        Person Update(Person entity);
        Person Remove(int id);
    }
}
