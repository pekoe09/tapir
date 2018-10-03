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
                new Person{LastName="Avanne", FirstNames="Aarne Aatami", DOB=new DateTime(1960, 6, 30)},
                new Person{LastName="Bergström", FirstNames="Bertta Berit", DOB=new DateTime(1971, 12, 31)},
                new Person{LastName="Cronqvist", FirstNames="Cecilia Cella", DOB=new DateTime(1982, 1, 13)}
            };
            foreach (Person p in persons)
            {
                context.Persons.Add(p);
            }
            context.SaveChanges();

            var employments = new Employment[]
            {
                new Employment{
                    PersonID = (int)persons.Single(p => p.LastName == "Avanne").ID,
                    CompanyID = (int)companies.Single(c => c.ShortName == "Oy1").ID
                },
                new Employment{
                    PersonID = (int)persons.Single(p => p.LastName == "Bergström").ID,
                    CompanyID = (int)companies.Single(c => c.ShortName == "Oy1").ID
                },
                new Employment{
                    PersonID = (int)persons.Single(p => p.LastName == "Bergström").ID,
                    CompanyID = (int)companies.Single(c => c.ShortName == "Oy2").ID
                },
                new Employment{
                    PersonID = (int)persons.Single(p => p.LastName == "Cronqvist").ID,
                    CompanyID = (int)companies.Single(c => c.ShortName == "Oy2").ID
                },
            };
            foreach (Employment e in employments)
            {
                context.Employments.Add(e);
            }
            context.SaveChanges();
        }
    }
}
