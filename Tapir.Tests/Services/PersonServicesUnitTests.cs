using System;
using System.Collections.Generic;
using Xunit;
using Moq;
using Tapir.Services;
using Tapir.Core;
using Tapir.Models;

namespace Tapir.UnitTests.Services
{
    public class PersonServicesUnitTests
    {
        private readonly PersonService personService;
        private List<Person> persons;

        public PersonServicesUnitTests()
        {
            persons = new List<Person>
            {
                new Person()
                {
                    ID = 1,
                    LastName = "Last1",
                    FirstNames = "First1",
                    SSN = "SSN1",
                    Address = new Address()
                    {
                        Street1 = "1Street1",
                        Street2 = "1Street2",
                        Zip = "1Zip",
                        City = "1City",
                        Country = "1Country"
                    },
                    Email = "Email1",
                    Phone = "Phone1",
                    Language = "Lang1",
                    Citizenship = "Citizen1",
                    Profession = "Profession1",
                    IBAN = "IBAN1",
                    IsOwner = false,
                    PositionInCompany = "Position1",
                    PlaceOfRegularEmployment = "Place1",
                    CityOfRegularEmployment = "City1",
                    RegularEmploymentAddress = new Address()
                    {
                        Street1 = "RegStreet1",
                        Street2 = "RegStreet2",
                        Zip = "RegZip1",
                        City = "RegCity1",
                        Country = "RegCountry1"
                    }
                },
                new Person()
                {
                    ID = 2,
                    LastName = "Last2",
                    FirstNames = "First2",
                    SSN = "SSN2",
                    Address = new Address()
                    {
                        Street1 = "2Street1",
                        Street2 = "2Street2",
                        Zip = "2Zip",
                        City = "2City",
                        Country = "2Country"
                    },
                    Email = "Email2",
                    Phone = "Phone2",
                    Language = "Lang2",
                    Citizenship = "Citizen2",
                    Profession = "Profession2",
                    IBAN = "IBAN2",
                    IsOwner = false,
                    PositionInCompany = "Position2",
                    PlaceOfRegularEmployment = "Place2",
                    CityOfRegularEmployment = "City2",
                    RegularEmploymentAddress = new Address()
                    {
                        Street1 = "RegStreet1",
                        Street2 = "RegStreet2",
                        Zip = "RegZip2",
                        City = "RegCity2",
                        Country = "RegCountry2"
                    }
                },
                new Person()
                {
                    ID = 3,
                    LastName = "Last3",
                    FirstNames = "First3",
                    SSN = "SSN3",
                    Address = new Address()
                    {
                        Street1 = "3Street1",
                        Street2 = "3Street2",
                        Zip = "3Zip",
                        City = "3City",
                        Country = "3Country"
                    },
                    Email = "Email3",
                    Phone = "Phone3",
                    Language = "Lang3",
                    Citizenship = "Citizen3",
                    Profession = "Profession3",
                    IBAN = "IBAN3",
                    IsOwner = false,
                    PositionInCompany = "Position3",
                    PlaceOfRegularEmployment = "Place3",
                    CityOfRegularEmployment = "City3",
                    RegularEmploymentAddress = new Address()
                    {
                        Street1 = "RegStreet1",
                        Street2 = "RegStreet2",
                        Zip = "RegZip3",
                        City = "RegCity3",
                        Country = "RegCountry3"
                    }
                }
            };
            var mockRepository = new Mock<IPersonsRepository>();
            mockRepository.Setup(x => x.GetAll()).Returns(persons);
            mockRepository.Setup(x => x.GetById(2)).Returns(persons[1]);
            mockRepository.Setup(x => x.Insert(It.IsAny<Person>())).Returns((Person p) => p);
            personService = new PersonService(mockRepository.Object);
        }

        [Fact]
        public void ReturnsAllPersons()
        {
            var result = personService.GetPersons();

            Assert.IsType<List<PersonDTO>>(result);
            Assert.Equal(3, result.Count);
        }

        [Fact]
        public void ReturnsPersonByID()
        {
            var result = personService.GetPerson(2);

            Assert.IsType<PersonDTO>(result);
            Assert.Equal(2, ((PersonDTO)result).ID);
        }

        [Fact]
        public void ReturnsNullWhenGettingByNonexistingId()
        {
            var result = personService.GetPerson(300);

            Assert.Null(result);
        }

        [Fact]
        public void AddsPerson()
        {
            var mockRepository = new Mock<IPersonsRepository>();
            mockRepository.Setup(x => x.Insert(It.IsAny<Person>()))
                .Returns((Person p) => new Person()
                {
                    ID = 4,
                    LastName = p.LastName,
                    FirstNames = p.FirstNames,
                    Address = p.Address,
                    Email = p.Email,
                    Phone = p.Phone,
                    Language = p.Language,
                    Citizenship = p.Citizenship,
                    Profession = p.Profession,
                    IBAN = p.IBAN,
                    IsOwner = p.IsOwner,
                    OwnershipSelf = p.OwnershipSelf,
                    VotesSelf = p.VotesSelf,
                    OwnershipWithFamily = p.OwnershipWithFamily,
                    VotesWithFamily = p.VotesWithFamily,
                    PositionInCompany = p.PositionInCompany,
                    PlaceOfRegularEmployment = p.PlaceOfRegularEmployment,
                    CityOfRegularEmployment = p.CityOfRegularEmployment,
                    RegularEmploymentAddress = p.RegularEmploymentAddress
                });
            PersonService service = new PersonService(mockRepository.Object);

            PersonDTO dto = new PersonDTO()
            {
                LastName = "Last4",
                FirstNames = "First4",
                Address = new AddressDTO()
                {
                    Street1 = "Street14",
                    Street2 = "Street24",
                    Zip = "Zip4",
                    City = "City4",
                    Country = "Country4"
                },
                Email = "Email4",
                Phone = "Phone4",
                Language = "Language4",
                Citizenship = "Citizenship4",
                Profession = "Profession4",
                IBAN = "IBAN4",
                IsOwner = true,
                OwnershipSelf = 10.0,
                VotesSelf = 20.0,
                OwnershipWithFamily = 30.0,
                VotesWithFamily = 40.0,
                PositionInCompany = "Position4",
                PlaceOfRegularEmployment = "Place4",
                CityOfRegularEmployment = "RegCity4",
                RegularEmploymentAddress = new AddressDTO()
                {
                    Street1 = "RegStreet14",
                    Street2 = "RegStreet24",
                    Zip = "RegZip4",
                    City = "RegCity4",
                    Country = "RegCountry4"
                }
            };
            var result = service.SavePerson(dto);

            mockRepository.Verify(x => x.Insert(It.IsAny<Person>()), Times.Once);
            Assert.IsType<PersonDTO>(result);
            Assert.Equal(dto.LastName, result.LastName);
            Assert.Equal(dto.FirstNames, result.FirstNames);
            Assert.Equal(dto.SSN, result.SSN);
            Assert.Equal(dto.Address.Street1, result.Address.Street1);
            Assert.Equal(dto.Address.Street2, result.Address.Street2);
            Assert.Equal(dto.Address.Zip, result.Address.Zip);
            Assert.Equal(dto.Address.City, result.Address.City);
            Assert.Equal(dto.Address.Country, result.Address.Country);
            Assert.Equal(dto.Email, result.Email);
            Assert.Equal(dto.Phone, result.Phone);
            Assert.Equal(dto.Language, result.Language);
            Assert.Equal(dto.Citizenship, result.Citizenship);
            Assert.Equal(dto.Profession, result.Profession);
            Assert.Equal(dto.IBAN, result.IBAN);
            Assert.Equal(dto.IsOwner, result.IsOwner);
            Assert.True(result.OwnershipSelf - dto.OwnershipSelf < 0.001);
            Assert.True(result.VotesSelf - dto.VotesSelf < 0.001);
            Assert.True(result.OwnershipWithFamily - dto.OwnershipWithFamily < 0.001);
            Assert.True(result.VotesWithFamily - dto.VotesWithFamily < 0.001);
            Assert.Equal(dto.PositionInCompany, result.PositionInCompany);
            Assert.Equal(dto.PlaceOfRegularEmployment, result.PlaceOfRegularEmployment);
            Assert.Equal(dto.CityOfRegularEmployment, result.CityOfRegularEmployment);
            Assert.Equal(dto.RegularEmploymentAddress.Street1, result.RegularEmploymentAddress.Street1);
            Assert.Equal(dto.RegularEmploymentAddress.Street2, result.RegularEmploymentAddress.Street2);
            Assert.Equal(dto.RegularEmploymentAddress.Zip, result.RegularEmploymentAddress.Zip);
            Assert.Equal(dto.RegularEmploymentAddress.City, result.RegularEmploymentAddress.City);
            Assert.Equal(dto.RegularEmploymentAddress.Country, result.RegularEmploymentAddress.Country);
            Assert.NotNull(result.ID);
        }

        [Fact]
        public void AddingNullReturnsNull()
        {
            var mockRepository = new Mock<IPersonsRepository>();
            PersonService service = new PersonService(mockRepository.Object);

            var result = service.SavePerson(null);

            mockRepository.Verify(x => x.Insert(It.IsAny<Person>()), Times.Never);
            Assert.Null(result);
        }

        [Fact]
        public void AddingWithoutRequiredFieldsThrowsException()
        {
            var mockRepository = new Mock<IPersonsRepository>();
            PersonService service = new PersonService(mockRepository.Object);

            PersonDTO dto = new PersonDTO()
            {
                LastName = "last",
                Address = new AddressDTO()
                {
                    Street1 = "Street14",
                    Street2 = "Street24",
                    Zip = "Zip4",
                    City = "City4",
                    Country = "Country4"
                },
                RegularEmploymentAddress = new AddressDTO()
                {
                    Street1 = "RegStreet14",
                    Street2 = "RegStreet24",
                    Zip = "RegZip4",
                    City = "RegCity4",
                    Country = "RegCountry4"
                }
            };

            Assert.Throws<ArgumentException>(() => service.SavePerson(dto));
            mockRepository.Verify(x => x.Insert(It.IsAny<Person>()), Times.Never);
        }
    }
}