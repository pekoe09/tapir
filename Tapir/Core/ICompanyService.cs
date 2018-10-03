using System.Collections.Generic;

namespace Tapir.Core
{
    public interface ICompanyService
    {
        List<CompanyDTO> GetCompanies();
        CompanyDTO GetCompany(int ID);
        CompanyDTO SaveCompany(CompanyDTO company);
        CompanyDTO RemoveCompany(int ID);
    }
}
