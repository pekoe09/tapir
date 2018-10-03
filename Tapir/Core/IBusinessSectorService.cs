using System.Collections.Generic;

namespace Tapir.Core
{
    public interface IBusinessSectorService
    {
        List<BusinessSectorDTO> GetSectors();
        BusinessSectorDTO GetSector(int id);
        BusinessSectorDTO SaveSector(BusinessSectorDTO sector);
        BusinessSectorDTO RemoveSector(int id);
    }
}
