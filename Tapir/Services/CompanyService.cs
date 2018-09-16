using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tapir.Core;
using Tapir.Models;

namespace Tapir.Services
{
    public class CompanyService : ICompanyService
    {
        private ICompaniesRepository companiesRepository;

        public CompanyService(ICompaniesRepository companiesRepository)
        {
            this.companiesRepository = companiesRepository;
        }

        public List<CompanyDto> GetCompanies()
        {
            IEnumerable<Company> companies = companiesRepository.GetAll();
            List<CompanyDto> companyDtos = new List<CompanyDto>();
            foreach (Company c in companies)
            {
                companyDtos.Add(c.getDTO());
            }
            return companyDtos;
        }

        public CompanyDto GetCompany(int id)
        {
            Company company = companiesRepository.GetById(id);
            if (company != null)
            {
                return company.getDTO();
            }
            else
            {
                return null;
            }
        }

        public CompanyDto SaveCompany(CompanyDto company)
        {
            if (company == null)
            {
                return null;
            }
            if (string.IsNullOrWhiteSpace(company.FullName))
            {
                throw new ArgumentException("Full name is missing.");
            }
            if (string.IsNullOrWhiteSpace(company.ShortName))
            {
                throw new ArgumentException("Short name is missing");
            }
            Company savedCompany = null;
            if (company.ID.HasValue)
            {
                savedCompany = companiesRepository.Update(Company.Hydrate(company));
            }
            else
            {
                savedCompany = companiesRepository.Insert(Company.Hydrate(company));
            }
            if (savedCompany != null)
            {
                return savedCompany.getDTO();
            }
            else
            {
                return null;
            }
        }

        public CompanyDto RemoveCompany(int id)
        {
            CompanyDto deletedCompany = GetCompany(id);
            if (deletedCompany != null)
            {
                companiesRepository.Remove(id);
            }
            return deletedCompany;
        }
    }
}
