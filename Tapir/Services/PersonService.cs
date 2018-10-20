using System;
using System.Collections.Generic;
using Tapir.Core;
using Tapir.Models;
using System.ComponentModel.DataAnnotations;

namespace Tapir.Services
{
    public class PersonService : IPersonService
    {
        private IPersonsRepository personsRepository;

        public PersonService(IPersonsRepository personsRepository)
        {
            this.personsRepository = personsRepository;
        }

        public List<PersonDTO> GetPersons()
        {
            IEnumerable<Person> persons = personsRepository.GetAll();
            List<PersonDTO> personDTOs = new List<PersonDTO>();
            foreach (Person p in persons)
            {
                personDTOs.Add(p.getDTO());
            }
            return personDTOs;
        }

        public PersonDTO GetPerson(int id)
        {
            Person person = personsRepository.GetById(id);
            if (person != null)
            {
                return person.getDTO();
            }
            else
            {
                return null;
            }
        }

        public PersonDTO SavePerson(PersonDTO person)
        {
            if (person == null)
            {
                return null;
            }
            if (!Validator.TryValidateObject(person, new ValidationContext(person), new List<ValidationResult>()))
            {
                throw new ArgumentException("PersonDTO instance fails validation");
            }
            Person savedPerson = null;
            if (person.ID.HasValue)
            {
                savedPerson = personsRepository.Update(Person.Hydrate(person));
            }
            else
            {
                savedPerson = personsRepository.Insert(Person.Hydrate(person));
            }
            if (savedPerson != null)
            {
                return savedPerson.getDTO();
            }
            else
            {
                return null;
            }
        }

        public PersonDTO RemovePerson(int id)
        {
            PersonDTO deletedPerson = GetPerson(id);
            if (deletedPerson != null)
            {
                personsRepository.Remove(id);
            }
            return deletedPerson;
        }
    }
}
