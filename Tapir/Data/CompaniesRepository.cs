using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Tapir.Models
{
    public class CompaniesRepository : ICompaniesRepository
    {
        private readonly TapirContext context;

        public CompaniesRepository(TapirContext context)
        {
            this.context = context;
        }

        public IEnumerable<Company> GetAll()
        {
            return context.Companies.Include(c => c.Sector).AsEnumerable();
        }

        public Company GetById(int id)
        {
            return context.Companies.Include(c => c.Sector).Single(c => c.ID == id);
        }

        public Company Insert(Company company)
        {
            context.Companies.Add(company);
            context.SaveChanges();
            return company;
        }

        public Company Update(Company company)
        {
            Company updatedCompany = GetById((int)company.ID);
            if(updatedCompany == null)
            {
                return null;
            }
            updatedCompany.FullName = company.FullName;
            updatedCompany.ShortName = company.ShortName;
            updatedCompany.BusinessId = company.BusinessId;
            updatedCompany.Addresses = company.Addresses;
            updatedCompany.Sector = company.Sector;
            updatedCompany.InsuranceNumber = company.InsuranceNumber;
            updatedCompany.BankAccount = company.BankAccount;

            context.Companies.Update(updatedCompany);
            context.SaveChanges();
            return updatedCompany;
        }

        public Company Remove(int id)
        {
            Company deletedCompany = GetById(id);
            if(deletedCompany != null)
            {
                context.Companies.Remove(deletedCompany);
                context.SaveChanges();
                return deletedCompany;
            }
            else
            {
                return null;
            }
        }
    }
}
