using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
        public ActionResult<List<CompanyDto>> GetAll()
        {
            List<CompanyDto> companies = companyService.GetCompanies();
            return companies;
        }

        [HttpGet("{id}", Name = "GetCompany")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<CompanyDto> GetById(int id)
        {
            CompanyDto company = companyService.GetCompany(id);
            if (company == null)
            {
                return NotFound();
            }
            return company;
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult<CompanyDto> Create(CompanyDto company)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            CompanyDto newCompany = companyService.SaveCompany(company);
            return CreatedAtRoute(routeName: "GetCompany", routeValues: new { id = newCompany.ID }, value: newCompany);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult<CompanyDto> Update(int id, CompanyDto company)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            CompanyDto updatedCompany = companyService.SaveCompany(company);
            if(updatedCompany == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public ActionResult<CompanyDto> Delete(int id)
        {
            CompanyDto deletedCompany = companyService.RemoveCompany(id);
            if (deletedCompany == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}