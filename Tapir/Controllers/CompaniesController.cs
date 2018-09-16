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
        public IActionResult Get()
        {
            List<CompanyDto> companies = companyService.GetCompanies();
            return null;
        }

        [HttpPost]
        public IActionResult Post([FromBody] CompanyDto company)
        {
            CompanyDto newCompany = companyService.SaveCompany(company);
            return null;
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CompanyDto company)
        {
            CompanyDto updatedCompany = companyService.SaveCompany(company);
            return null;
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            CompanyDto deletedCompany = companyService.RemoveCompany(id);
            return null;
        }
    }
}