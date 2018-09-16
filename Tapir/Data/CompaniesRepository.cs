using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            return context.Companies.AsEnumerable();
        }

        public Company GetById(int id)
        {
            return context.Companies.Single(c => c.ID == id);
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
            if(updatedCompany != null)
            {
                return null;
            }
            updatedCompany.FullName = company.FullName;
            updatedCompany.ShortName = company.ShortName;
            context.Companies.Update(updatedCompany);
            return updatedCompany;
        }

        public Company Remove(int id)
        {
            Company deletedCompany = GetById(id);
            if(deletedCompany != null)
            {
                context.Companies.Remove(deletedCompany);
                return deletedCompany;
            }
            else
            {
                return null;
            }
        }
    }
}
