using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

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
            return context.Persons
                .Include(p => p.Address)
                .Include(p => p.RegularEmploymentAddress)
                .AsEnumerable();
        }

        public Person GetById(int id)
        {
            return context.Persons
                .Include(p => p.Address)
                .Include(p => p.RegularEmploymentAddress)
                .Single(p => p.ID == id);
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
            updatedPerson.SSN = person.SSN;
            updatedPerson.Address = person.Address;
            updatedPerson.Email = person.Email;
            updatedPerson.Phone = person.Phone;
            updatedPerson.Language = person.Language;
            updatedPerson.Citizenship = person.Citizenship;
            updatedPerson.Profession = person.Profession;
            updatedPerson.IBAN = person.IBAN;
            updatedPerson.IsOwner = person.IsOwner;
            updatedPerson.OwnershipSelf = person.OwnershipSelf;
            updatedPerson.VotesSelf = person.VotesSelf;
            updatedPerson.OwnershipWithFamily = person.OwnershipWithFamily;
            updatedPerson.VotesWithFamily = person.VotesWithFamily;
            updatedPerson.PositionInCompany = person.PositionInCompany;
            updatedPerson.PlaceOfRegularEmployment = person.PlaceOfRegularEmployment;
            updatedPerson.CityOfRegularEmployment = person.CityOfRegularEmployment;
            updatedPerson.RegularEmploymentAddress = person.RegularEmploymentAddress;

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
