using System.Collections.Generic;

namespace Tapir.Core
{
    public interface IPersonService
    {
        List<PersonDTO> GetPersons();
        PersonDTO GetPerson(int id);
        PersonDTO SavePerson(PersonDTO person);
        PersonDTO RemovePerson(int id);
    }
}
