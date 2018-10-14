using System;
using System.Linq;

namespace Tapir.Models
{
    public class DbInitializer
    {
        public static void Initialize(TapirContext context)
        {
            if (context.Companies.Any())
            {
                return;
            }

            var sectors = new BusinessSector[]
            {
                new BusinessSector{Code="0001", Name="Agriculture"},
                new BusinessSector{Code="0002", Name="Mining"},
                new BusinessSector{Code="0003", Name="Oil refining"}
            };
            foreach (BusinessSector s in sectors)
            {
                context.BusinessSectors.Add(s);
            }
            context.SaveChanges();

            var companies = new Company[]
            {
                new Company
                {
                    FullName ="Osakeyhtiö 1 Oy",
                    ShortName ="Oy1",
                    BusinessId = "11111-1",
                    Sector = sectors.Single(s => s.Code == "0001"),
                    InsuranceNumber = "aaa111",
                    BankAccount = "11111-11111"
                },
                new Company
                {
                    FullName ="Osakeyhtiö 2 Oy",
                    ShortName ="Oy2",
                    BusinessId = "22222-2",
                    Sector = sectors.Single(s => s.Code == "0002"),
                    InsuranceNumber = "bbb222",
                    BankAccount = "22222-22222"
                },
                new Company
                {
                    FullName ="Osakeyhtiö 3 Oy",
                    ShortName ="Oy3",
                    BusinessId = "33333-3",
                    Sector = sectors.Single(s => s.Code == "0003"),
                    InsuranceNumber = "ccc333",
                    BankAccount = "33333-33333"
                }
            };
            foreach (Company c in companies)
            {
                context.Companies.Add(c);
            }
            context.SaveChanges();

            var persons = new Person[]
            {
                new Person{
                    LastName = "Avanne",
                    FirstNames = "Aarne Aatami",
                    SSN = "111111-1111",
                    Address = new Address
                    {
                        Street1 = "Testikatu 1",
                        Zip = "11111",
                        City = "1City",
                        Country = "1Country"
                    },
                    Email = "aarne.avanne@a.com",
                    Phone = "+358 111 111",
                    Language = "FI",
                    Citizenship = "Finnish",
                    Profession = "Avantouimari",
                    IBAN = "FI111100001111",
                    IsOwner = false
                },
                new Person{
                    LastName = "Bergström",
                    FirstNames = "Bertta Berit",
                    SSN = "222222-2222",
                    Address = new Address
                    {
                        Street1 = "Testikatu 2",
                        Zip = "22222",
                        City = "2City",
                        Country = "2Country"
                    },
                    Email = "bertta.bergstrom@b.com",
                    Phone = "+358 222 222",
                    Language = "SE",
                    Citizenship = "Finnish",
                    Profession = "Borgmästare",
                    IBAN = "FI222200002222",
                    IsOwner = true,
                    OwnershipSelf = 75.1,
                    VotesSelf = 90.2,
                    OwnershipWithFamily = 85.0,
                    VotesWithFamily = 95.3,
                    PositionInCompany = "Chairperson",
                    PlaceOfRegularEmployment = "Huvudkontor",
                    CityOfRegularEmployment = "Helsingfors",
                    RegularEmploymentAddress = new Address
                    {
                        Street1 = "Kaivokatu 2",
                        Zip = "00100",
                        City = "Helsingfors",
                        Country = "Finland"
                    }
                },
                new Person{
                    LastName = "Cronqvist",
                    FirstNames = "Cecilia Cella",
                    SSN = "333333-3333",
                    Address = new Address
                    {
                        Street1 = "Testikatu 3",
                        Zip = "33333",
                        City = "3City",
                        Country = "3Country"
                    },
                    Email = "cella@c.com",
                    Phone = "+358 333 333",
                    Language = "SE",
                    Citizenship = "Swedish",
                    Profession = "Chantreuse",
                    IBAN = "FI333300003333",
                    IsOwner = false
                }
            };
            foreach (Person p in persons)
            {
                context.Persons.Add(p);
            }
            context.SaveChanges();

            var employments = new Employment[]
            {
                new Employment{
                    Company = companies[0],
                    Person = persons[0],
                    StartDate = new DateTime(2000, 12, 1),
                    IsMainOccupation = true,
                    IsFullTime = true,
                    IsCalledToWork = false,
                    WeeklyHours = 37.5,
                    IsStudent = false,
                    IsPensioner = false,
                    HasOtherEmployments = false
                }
            };
            foreach (Employment e in employments)
            {
                context.Employments.Add(e);
            }
            context.SaveChanges();
        }
    }
}
