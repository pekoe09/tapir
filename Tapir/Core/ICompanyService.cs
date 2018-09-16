using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tapir.Core
{
    public interface ICompanyService
    {
        List<CompanyDto> GetCompanies();
        CompanyDto GetCompany(int ID);
        CompanyDto SaveCompany(CompanyDto company);
        CompanyDto RemoveCompany(int ID);
    }
}
