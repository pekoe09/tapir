using System.Collections.Generic;

namespace Tapir.Models
{
    public interface ICompaniesRepository
    {
        IEnumerable<Company> GetAll();
        Company GetById(int id);
        Company Insert(Company entity);
        Company Update(Company entity);
        Company Remove(int id);
    }
}
