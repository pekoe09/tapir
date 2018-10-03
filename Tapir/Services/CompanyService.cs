using System;
using System.Collections.Generic;
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

        public List<CompanyDTO> GetCompanies()
        {
            IEnumerable<Company> companies = companiesRepository.GetAll();
            List<CompanyDTO> companyDtos = new List<CompanyDTO>();
            foreach (Company c in companies)
            {
                companyDtos.Add(c.getDTO());
            }
            return companyDtos;
        }

        public CompanyDTO GetCompany(int id)
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

        public CompanyDTO SaveCompany(CompanyDTO company)
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
            if (company.Id.HasValue)
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

        public CompanyDTO RemoveCompany(int id)
        {
            CompanyDTO deletedCompany = GetCompany(id);
            if (deletedCompany != null)
            {
                companiesRepository.Remove(id);
            }
            return deletedCompany;
        }
    }
}
