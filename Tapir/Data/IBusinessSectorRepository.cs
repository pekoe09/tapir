using System.Collections.Generic;

namespace Tapir.Models
{
    public interface IBusinessSectorRepository
    {
        IEnumerable<BusinessSector> GetAll();
        BusinessSector GetById(int id);
        BusinessSector Insert(BusinessSector entity);
        BusinessSector Update(BusinessSector entity);
        BusinessSector Remove(int id);
    }
}
