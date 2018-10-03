using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Tapir.Core;

namespace Tapir.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private ICompanyService companyService;

        public CompaniesController(ICompanyService companyService)
        {
            this.companyService = companyService;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public ActionResult<List<CompanyDTO>> GetAll()
        {
            List<CompanyDTO> companies = companyService.GetCompanies();
            return companies;
        }

        [HttpGet("{id}", Name = "GetCompany")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<CompanyDTO> GetById(int id)
        {
            CompanyDTO company = companyService.GetCompany(id);
            if (company == null)
            {
                return NotFound();
            }
            return company;
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult<CompanyDTO> Create(CompanyDTO company)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            CompanyDTO newCompany = companyService.SaveCompany(company);
            return CreatedAtRoute(routeName: "GetCompany", routeValues: new { id = newCompany.Id }, value: newCompany);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult<CompanyDTO> Update(int id, CompanyDTO company)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            CompanyDTO updatedCompany = companyService.SaveCompany(company);
            if (updatedCompany == null)
            {
                return NotFound();
            }
            return Ok(updatedCompany);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<CompanyDTO> Delete(int id)
        {
            CompanyDTO deletedCompany = companyService.RemoveCompany(id);
            if (deletedCompany == null)
            {
                return NotFound();
            }
            return Ok(deletedCompany);
        }
    }
}