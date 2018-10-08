using System.Collections.Generic;

namespace Tapir.Models
{
    public interface IEmploymentRepository
    {
        IEnumerable<Employment> GetAll();
        Employment GetById(int id);
        Employment Insert(Employment entity);
        Employment Update(Employment entity);
        Employment Remove(int id);
    }
}
