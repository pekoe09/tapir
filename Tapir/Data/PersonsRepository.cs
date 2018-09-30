using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tapir.Models
{
    public class PersonsRepository : IPersonsRepository
    {
        private readonly TapirContext context;

        public PersonsRepository(TapirContext context)
        {
            this.context = context;
        }

        public IEnumerable<Person> GetAll()
        {
            return context.Persons.AsEnumerable();
        }

        public Person GetById(int id)
        {
            return context.Persons.Single(p => p.ID == id);
        }

        public Person Insert(Person person)
        {
            context.Persons.Add(person);
            context.SaveChanges();
            return person;
        }
        
        public Person Update(Person person)
        {
            Person updatedPerson = GetById((int)person.ID);
            if(updatedPerson == null)
            {
                return null;
            }
            updatedPerson.LastName = person.LastName;
            updatedPerson.FirstNames = person.FirstNames;
            updatedPerson.DOB = person.DOB;
            context.Persons.Update(updatedPerson);
            context.SaveChanges();
            return updatedPerson;
        }

        public Person Remove(int id)
        {
            Person deletedPerson = GetById(id);
            if(deletedPerson != null)
            {
                context.Persons.Remove(deletedPerson);
                context.SaveChanges();
                return deletedPerson;
            }
            else
            {
                return null;
            }
        }
    }
}
