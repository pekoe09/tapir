using System;
using System.Collections.Generic;
using Tapir.Core;
using Tapir.Models;

namespace Tapir.Services
{
    public class BusinessSectorService : IBusinessSectorService
    {
        private IBusinessSectorRepository sectorRepository;

        public BusinessSectorService(IBusinessSectorRepository sectorRepository)
        {
            this.sectorRepository = sectorRepository;
        }

        public List<BusinessSectorDTO> GetSectors()
        {
            IEnumerable<BusinessSector> sectors = sectorRepository.GetAll();
            List<BusinessSectorDTO> sectorDTOs = new List<BusinessSectorDTO>();
            foreach (BusinessSector s in sectors)
            {
                sectorDTOs.Add(s.getDTO());
            }
            return sectorDTOs;
        }

        public BusinessSectorDTO GetSector(int id)
        {
            BusinessSector sector = sectorRepository.GetById(id);
            if(sector != null)
            {
                return sector.getDTO();
            }
            else
            {
                return null;
            }
        }

        public BusinessSectorDTO SaveSector(BusinessSectorDTO sector)
        {
            if (sector == null)
            {
                return null;
            }
            BusinessSector savedSector = null;
            if(sector.Id.HasValue)
            {
                savedSector = sectorRepository.Update(BusinessSector.Hydrate(sector));
            }
            else
            {
                savedSector = sectorRepository.Insert(BusinessSector.Hydrate(sector));
            }
            if(savedSector != null)
            {
                return savedSector.getDTO();
            }
            else
            {
                return null;
            }
        }

        public BusinessSectorDTO RemoveSector(int id)
        {
            BusinessSectorDTO deletedSector = GetSector(id);
            if(deletedSector != null)
            {
                sectorRepository.Remove(id);
            }
            return deletedSector;
        }
    }
}
