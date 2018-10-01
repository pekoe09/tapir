using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Tapir.Models
{
    public class BusinessSectorRepository : IBusinessSectorRepository
    {
        private readonly TapirContext context;

        public BusinessSectorRepository(TapirContext context)
        {
            this.context = context;
        }

        public IEnumerable<BusinessSector> GetAll()
        {
            return context.BusinessSectors.AsEnumerable();
        }

        public BusinessSector GetById(int id)
        {
            return context.BusinessSectors.Single(s => s.ID == id);
        }

        public BusinessSector Insert(BusinessSector sector)
        {
            context.BusinessSectors.Add(sector);
            context.SaveChanges();
            return sector;
        }

        public BusinessSector Update(BusinessSector sector)
        {
            BusinessSector updatedSector = GetById((int)sector.ID);
            if(updatedSector == null)
            {
                return null;
            }
            updatedSector.Code = sector.Code;
            updatedSector.Name = sector.Name;
            context.BusinessSectors.Update(updatedSector);
            context.SaveChanges();
            return updatedSector;
        }

        public BusinessSector Remove(int id)
        {
            BusinessSector deletedSector = GetById(id);
            if(deletedSector != null)
            {
                context.BusinessSectors.Remove(deletedSector);
                context.SaveChanges();
                return deletedSector;
            }
            else
            {
                return null;
            }
        }
    }
}
