using System.Collections.Generic;

namespace Tapir.Core
{
    public interface IEmploymentService
    {
        List<EmploymentDTO> GetEmployments();
        EmploymentDTO GetEmployment(int id);
        EmploymentDTO SaveEmployment(EmploymentDTO employment);
        EmploymentDTO RemoveEmployment(int id);
    }
}
