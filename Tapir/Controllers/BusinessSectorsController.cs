using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Tapir.Core;

namespace Tapir.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessSectorsController : ControllerBase
    {
        private IBusinessSectorService sectorService;

        public BusinessSectorsController(IBusinessSectorService sectorService)
        {
            this.sectorService = sectorService;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public ActionResult<List<BusinessSectorDTO>> GetAll()
        {
            List<BusinessSectorDTO> sectors = sectorService.GetSectors();
            return sectors;
        }

        [HttpGet("{id}", Name = "GetBusinessSector")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<BusinessSectorDTO> GetById(int id)
        {
            BusinessSectorDTO sector = sectorService.GetSector(id);
            if(sector == null)
            {
                return NotFound();
            }
            return sector;
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult<BusinessSectorDTO> Create(BusinessSectorDTO sector)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            BusinessSectorDTO newSector = sectorService.SaveSector(sector);
            return CreatedAtRoute(routeName: "GetBusinessSector", routeValues: new { id = newSector.Id }, value: newSector);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult<BusinessSectorDTO> Update(int id, BusinessSectorDTO sector)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            BusinessSectorDTO updatedSector = sectorService.SaveSector(sector);
            if(updatedSector == null)
            {
                return NotFound();
            }
            return Ok(updatedSector);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<BusinessSectorDTO> Delete(int id)
        {
            BusinessSectorDTO deletedSector = sectorService.RemoveSector(id);
            if(deletedSector == null)
            {
                return NotFound();
            }
            return Ok(deletedSector);
        }
    }
}