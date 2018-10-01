using System.Collections.Generic;

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
